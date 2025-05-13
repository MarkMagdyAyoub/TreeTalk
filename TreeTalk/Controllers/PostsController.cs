using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TreeTalk.Model.Entities;
using TreeTalk.Model.Entities.DTOs;
using TreeTalk.Model.Services;
using TreeTalkModel.Model.Data;
using TreeTalkModel.Model.Entities;

namespace TreeTalk.Controllers;

/// <summary>
/// Controller for handling post-related operations including feed display,
/// comment management, and like functionality.
/// </summary>
public class PostsController : Controller
{
  private readonly TreeTalkDbContext _context;

  public PostsController(TreeTalkDbContext context)
  {
    _context = context;
  }

  /// <summary>
  /// Displays the post feed with pagination support.
  /// </summary>
  /// <param name="page">The page number to display (1-based index).</param>
  /// <param name="pageSize">The number of posts per page.</param>
  /// <returns>A view containing the paginated post feed.</returns>
  [HttpGet]
  [Authorize]
  public async Task<IActionResult> Feed(int page = 1, int pageSize = 10)
  {
    var model = await _context.FeedDataAsync(page, pageSize);
    return View(model);
  }

  /// <summary>
  /// Adds a new comment to a post or as a reply to an existing comment.
  /// </summary>
  /// <param name="PostId">The ID of the post being commented on.</param>
  /// <param name="ParentId">The ID of the parent comment if this is a reply (optional).</param>
  /// <param name="Content">The content of the comment.</param>
  /// <returns>
  /// Redirects to the feed if successful, or returns an error response if validation fails.
  /// </returns>
  [HttpPost]
  [Authorize]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Add(int PostId, int? ParentId, string Content)
  {
    if (string.IsNullOrWhiteSpace(Content))
    {
      TempData["ErrorMessage"] = "Comment content cannot be empty.";
      return RedirectToAction("Feed", new { page = 1 });
    }

    var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userIdClaim, out var authorId))
    {
      TempData["ErrorMessage"] = "User not authenticated properly.";
      return Unauthorized();
    }

    var comment = new Comment
    {
      PostId = PostId,
      ParentId = ParentId,
      AuthorId = authorId,
      Content = Content.Trim(),
      Likes = 0,
      CreatedAt = DateTime.Now,
      IsDeleted = false
    };

    if (ParentId.HasValue)
    {
      var parent = await _context.Comments
          .Where(c => c.Id == ParentId.Value)
          .Select(c => new { c.Depth })
          .FirstOrDefaultAsync();

      if (parent == null)
      {
        TempData["ErrorMessage"] = "Parent comment not found.";
        return BadRequest();
      }

      comment.Depth = parent.Depth + 1;
    }
    else
    {
      comment.Depth = 0;
    }

    _context.Comments.Add(comment);
    await _context.SaveChangesAsync();

    return RedirectToAction("Index", "Home");
  }

  /// <summary>
  /// Toggles a like on a post for the specified user.
  /// </summary>
  /// <param name="userId">The ID of the user liking/unliking the post.</param>
  /// <param name="postId">The ID of the post being liked/unliked.</param>
  /// <returns>
  /// A JSON response indicating success/failure and the updated like count.
  /// </returns>
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> LikePost(int userId, int postId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    if (user == null)
    {
      return Json(new LikeResponseDto
      {
        Success = false,
        Message = "User not found"
      });
    }

    if (user.IsBanned || user.IsDeleted)
    {
      return Json(new LikeResponseDto
      {
        Success = false,
        Message = "User is inactive"
      });
    }

    var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
    if (post == null)
    {
      return Json(new LikeResponseDto
      {
        Success = false,
        Message = "Post not found"
      });
    }

    var existingLike = await _context.PostsLikes
        .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);

    if (existingLike != null)
    {
      // Unlike the post
      _context.PostsLikes.Remove(existingLike);
      post.Likes--;
    }
    else
    {
      // Like the post
      await _context.PostsLikes.AddAsync(new PostLike
      {
        PostId = postId,
        UserId = userId
      });
      post.Likes++;
    }

    await _context.SaveChangesAsync();

    return Json(new LikeResponseDto
    {
      Success = true,
      LikeCount = post.Likes,
      Liked = existingLike == null
    });
  }

  /// <summary>
  /// Toggles a like on a comment for the specified user.
  /// </summary>
  /// <param name="userId">The ID of the user liking/unliking the comment.</param>
  /// <param name="commentId">The ID of the comment being liked/unliked.</param>
  /// <returns>
  /// A JSON response indicating success/failure and the updated like count.
  /// </returns>
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> LikeComment(int userId, int commentId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    if (user == null)
    {
      return Json(new LikeResponseDto
      {
        Success = false,
        Message = "User not found"
      });
    }

    if (user.IsBanned || user.IsDeleted)
    {
      return Json(new LikeResponseDto
      {
        Success = false,
        Message = "User is inactive"
      });
    }

    var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
    if (comment == null || comment.IsDeleted)
    {
      return Json(new LikeResponseDto
      {
        Success = false,
        Message = "Comment not found or deleted"
      });
    }

    var existingLike = await _context.CommentsLikes
        .FirstOrDefaultAsync(c => c.CommentId == commentId && c.UserId == userId);

    if (existingLike != null)
    {
      // Unlike
      _context.CommentsLikes.Remove(existingLike);
      comment.Likes--;
    }
    else
    {
      // Like
      await _context.CommentsLikes.AddAsync(new CommentLike
      {
        CommentId = commentId,
        UserId = userId
      });
      comment.Likes++;
    }

    await _context.SaveChangesAsync();

    return Json(new LikeResponseDto
    {
      Success = true,
      LikeCount = comment.Likes,
      Liked = existingLike == null
    });
  }
}
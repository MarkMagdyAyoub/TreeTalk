using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TreeTalk.Model.ViewModels;
using TreeTalkModel.Model.Data;
using TreeTalkModel.Model.Entities;
using TreeTalkModel.Model.Entities.DTOs;

namespace TreeTalk.Model.Services;

// TODO: Need Improvement

/// <summary>
/// Provides extension methods for post-related data operations.
/// </summary>
public static class PostService
{
  /// <summary>
  /// Retrieves paginated post feed data with associated comments.
  /// </summary>
  /// <param name="context">The database context.</param>
  /// <param name="page">The current page number (1-based index).</param>
  /// <param name="pageSize">The number of posts per page.</param>
  /// <returns>
  /// A <see cref="PostFeedViewModel"/> containing:
  /// - Paginated posts with their comments
  /// - Pagination metadata (current page, total pages)
  /// </returns>
  /// <remarks>
  /// The method performs the following operations:
  /// 1. Gets total post count for pagination
  /// 2. Retrieves a random subset of posts for the requested page
  /// 3. Loads comments for each post using the get_comment_tree function
  /// 4. Constructs the complete view model with posts, comments, and pagination info
  /// </remarks>
  public static async Task<PostFeedViewModel> FeedDataAsync(this TreeTalkDbContext context, int page, int pageSize)
  {
    // Get total number of posts for pagination
    var totalPosts = await context.Posts.CountAsync();

    // Calculate total pages
    var totoalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);

    // Get paginated posts with random ordering
    var posts = await context.Posts
        .OrderBy(p => Guid.NewGuid()) // Random ordering
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Include(p => p.User) // Eager load author information
        .ToListAsync();

    // Prepare list to hold posts with their comments
    var postWithComments = new List<PostWithCommentsDto>();

    // Process each post to load comments and format data
    foreach (var post in posts)
    {
      // Get comment tree for the current post
      var comments = await context
          .get_comment_tree(post.Id)
          .ToListAsync();

      // Create DTO for the post with its comments
      postWithComments.Add(new PostWithCommentsDto
      {
        Post = new PostWithCommentsDto.PostDto
        {
          Id = post.Id,
          Title = post.Title ?? string.Empty,
          Content = post.Content ?? string.Empty,
          CreatedAt = post.CreatedAt,
          Likes = post.Likes,
          Author = new PostWithCommentsDto.AuthorDto
          {
            Username = post.User?.Username ?? string.Empty,
            ImageUrl = post.User?.UserImageUrl ?? string.Empty,
          }
        },
        Comments = comments
      });
    }

    // Create and return the complete view model
    var model = new PostFeedViewModel
    {
      PostsWithComments = postWithComments,
      CurrentPage = page,
      TotalPages = (int)Math.Ceiling((double)totalPosts / pageSize)
    };

    return model;
  }
}
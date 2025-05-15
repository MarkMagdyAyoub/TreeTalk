using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TreeTalk.Model.ViewModels;
using TreeTalkModel.Model.Data;
using TreeTalkModel.Model.DTOs;
using TreeTalkModel.Model.Entities;
using TreeTalkModel.Model.Entities.DTOs;

namespace TreeTalkModel.Model.Services;

/// <summary>
/// Provides services related to user profiles such as retrieving and updating profile information,
/// and paginating user posts with comments.
/// </summary>
public class UserProfileService
{
  private readonly TreeTalkDbContext _context;

  public UserProfileService(TreeTalkDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
  }

  /// <summary>
  /// Retrieves a user's profile information as a DTO.
  /// </summary>
  /// <param name="userId">The ID of the user whose profile is being retrieved.</param>
  /// <returns>A <see cref="UserProfileDto"/> if found; otherwise, <c>null</c>.</returns>
  public async Task<UserProfileDto?> GetProfileAsync(int userId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

    if (user == null)
      return null;

    return new UserProfileDto
    {
      Id = user!.Id,
      Username = user.Username!,
      Email = user.Email!,
      AboutMe = user.AboutMe,
      UserImageUrl = string.IsNullOrEmpty(user.UserImageUrl)
        ? "/images/defaultProfile.png"
        : user.UserImageUrl,
      BirthDate = user.Birthday,
      Gender = user.Gender,
    };
  }

  /// <summary>
  /// Retrieves a paginated list of posts made by a user along with their comments.
  /// </summary>
  /// <param name="userId">The ID of the user whose posts are being fetched.</param>
  /// <param name="pageNumber">The current page number for pagination.</param>
  /// <param name="pageSize">The number of posts per page.</param>
  /// <returns>A <see cref="PostFeedViewModel"/> containing the posts and comments for the specified page.</returns>
  /// <exception cref="ArgumentException">Thrown when the user does not exist, or pagination parameters are invalid.</exception>
  public async Task<PostFeedViewModel> GetPostPageAsync(int userId, int pageNumber, int pageSize)
  {
    var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

    if (existingUser == null)
      throw new ArgumentException("User Not Found");

    if (pageNumber <= 0 || pageSize <= 0)
      throw new ArgumentException("PageNumber And PageSize Must Be Positive Value");

    var totalPosts = await _context.Posts.CountAsync();

    var totoalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);

    var posts = await _context.Posts
        .Where(p => p.AuthorId == userId)
        .OrderByDescending(p => p.CreatedAt)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var postWithComments = new List<PostWithCommentsDto>();

    foreach (var post in posts)
    {
      var comments = await _context
          .get_comment_tree(post.Id)
          .ToListAsync();

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

    var model = new PostFeedViewModel
    {
      PostsWithComments = postWithComments,
      CurrentPage = pageNumber,
      TotalPages = (int)Math.Ceiling((double)totalPosts / pageSize)
    };

    return model;
  }

  /// <summary>
  /// Updates the birth date of the specified user.
  /// </summary>
  /// <param name="userid">The ID of the user whose birth date will be updated.</param>
  /// <param name="birthDate">The new birth date to assign.</param>
  /// <returns>A task representing the asynchronous operation.</returns>
  public async Task UpdateDateAync(int userid, DateTime birthDate)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid);
    user!.Birthday = birthDate;
    await _context.SaveChangesAsync();
  }

  /// <summary>
  /// Updates the "About Me" section of the specified user's profile.
  /// </summary>
  /// <param name="userid">The ID of the user whose information is being updated.</param>
  /// <param name="aboutMe">The new "About Me" content.</param>
  /// <returns>A task representing the asynchronous operation.</returns>
  public async Task UpdateAboutMeAsync(int userid, string aboutMe)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid);
    user!.AboutMe = aboutMe;
    await _context.SaveChangesAsync();
  }
}

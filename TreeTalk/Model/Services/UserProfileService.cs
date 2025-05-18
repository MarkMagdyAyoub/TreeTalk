using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TreeTalk.Model.Entities.DTOs;
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

  public async Task<User?> GetUserByIdAsync(int id) {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

    if (user != null)
    {
      return user;
    }
    else {
      return null;
    }
  }

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

  public async Task UpdateDateAync(int userid, DateTime birthDate)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid);
    if (user == null) throw new ArgumentException("User not found");
    user.Birthday = birthDate;
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAboutMeAsync(int userid, string aboutMe)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid);
    if (user == null) throw new ArgumentException("User not found");
    user.AboutMe = aboutMe;
    await _context.SaveChangesAsync();
  }

  public async Task UpdateGenderAsync(int userid, char gender)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid);
    if (user == null) throw new ArgumentException("User not found");

    if (gender != 'M' && gender != 'F')
      throw new ArgumentException("Gender must be 'M' or 'F'");

    user.Gender = gender;
    await _context.SaveChangesAsync();
  }

  public async Task UpdateUserProfileAsync(UpdateUserProfileRequest request)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
    if (user == null) throw new ArgumentException("User not found");

    user.AboutMe = request.AboutMe;
    user.Birthday = request.BirthDate;
    user.Gender = request.Gender;
    user.UserImageUrl = request.UserProfileImageUrl;

    await _context.SaveChangesAsync();
  }
}

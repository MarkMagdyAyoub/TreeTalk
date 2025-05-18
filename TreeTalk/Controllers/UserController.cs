using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TreeTalk.Model.Entities.DTOs;
using TreeTalkModel.Model.Data;
using TreeTalkModel.Model.Entities;
using TreeTalkModel.Model.Services;

namespace TreeTalk.Controllers;

/// <summary>
/// Controller responsible for managing user-related operations such as 
/// profile retrieval, post pagination, and updating profile data.
/// </summary>
[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : Controller
{
  private readonly UserProfileService _profileService;
  private readonly IWebHostEnvironment _env;

  public UserController(UserProfileService profileService, TreeTalkDbContext context, IWebHostEnvironment env)
  {
    _profileService = profileService;
    _env = env;
  }


  /// <summary>
  /// Retrieves the profile of the currently authenticated user and returns it as a view.
  /// </summary>
  /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
  [HttpGet("UserProfile")]
  public async Task<IActionResult> UserProfile()
  {
    int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    var profile = await _profileService.GetProfileAsync(userId);

    if (profile == null)
      return NotFound();

    return View("UserProfile", profile);
  }

  /// <summary>
  /// Retrieves a paginated list of posts for a specific user.
  /// </summary>
  /// <param name="request">The pagination request, including user ID, page number, and page size.</param>
  /// <returns>A partial view containing the posts if successful, or a bad request on failure.</returns>
  [HttpPost]
  [Route("GetUserPostsPage")]
  public async Task<IActionResult> GetUserPostsPage([FromBody] UserPostsPage request)
  {
    try
    {
      var model = await _profileService.GetPostPageAsync(request.UserId, request.PageNumber, request.PageSize);
      return PartialView("_UserPostsPartial", model);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(ex.Message);
    }
  }

  /// <summary>
  /// Updates the birth date for a specific user.
  /// </summary>
  /// <param name="request">Contains user ID and the new birth date.</param>
  /// <returns>An <see cref="IActionResult"/> indicating success.</returns>
  [HttpPut]
  [Route("UpdateBirthDate")]
  public async Task<IActionResult> UpdateBirthDate([FromBody] UpdateBirthDateRequest request)
  {
    await _profileService.UpdateDateAync(request.UserId, request.BirthDate);
    return Ok(new { Message = "User's BirthDate Updated Successfully" });
  }

  /// <summary>
  /// Updates the "About Me" section of a user's profile.
  /// </summary>
  /// <param name="request">Contains user ID and new "About Me" text.</param>
  /// <returns>An <see cref="IActionResult"/> indicating success.</returns>
  [HttpPut]
  [Route("UpdateAboutMe")]
  public async Task<IActionResult> UpdateAboutMe([FromBody] UpdateAboutMeRequest request)
  {
    await _profileService.UpdateAboutMeAsync(request.UserId, request.AboutMe);
    return Ok(new { Message = "User's AboutMe Updated Successfully" });
  }

  /// <summary>
  /// Updates the user's profile including profile picture, birth date, about me, and gender.
  /// </summary>
  [HttpPost("EditProfile")]
  public async Task<IActionResult> EditProfile(EditProfileRequest request)
  {
    int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    var user = await _profileService.GetUserByIdAsync(userId);

    if (user == null)
      return NotFound();

    string? newProfilePicturePath = user.UserImageUrl; // default to current image

    if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
    {
      // Delete old profile picture if it's not the default
      if (!string.IsNullOrEmpty(user.UserImageUrl) && !user.UserImageUrl.Contains("defaultProfile.png"))
      {
        var oldImagePath = Path.Combine(_env.WebRootPath, user.UserImageUrl.TrimStart('/'));
        if (System.IO.File.Exists(oldImagePath))
        {
          System.IO.File.Delete(oldImagePath);
        }
      }

      // Save the new image
      var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.ProfilePicture.FileName)}";
      var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "profiles");
      Directory.CreateDirectory(uploadPath);

      var filePath = Path.Combine(uploadPath, fileName);
      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await request.ProfilePicture.CopyToAsync(stream);
      }

      newProfilePicturePath = $"/uploads/profiles/{fileName}";
    }

    // Update the user info
    await _profileService.UpdateUserProfileAsync(new UpdateUserProfileRequest
    {
      UserId = userId,
      AboutMe = request.AboutMe,
      Gender = request.Gender,
      BirthDate = request.BirthDate,
      UserProfileImageUrl = newProfilePicturePath!
    });

    return RedirectToAction("UserProfile");
  }


}

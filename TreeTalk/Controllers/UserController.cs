using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TreeTalk.Model.Entities.DTOs;
using TreeTalkModel.Model.Data;
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

  public UserController(UserProfileService profileService, TreeTalkDbContext context)
  {
    _profileService = profileService;
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
}

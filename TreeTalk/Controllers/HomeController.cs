using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TreeTalk.Model.Services;
using TreeTalkModel.Model.Data;

namespace TreeTalk.Controllers;

public class HomeController : Controller
{
  private readonly TreeTalkDbContext _context;

  public HomeController(TreeTalkDbContext context) {
    _context = context;
  }
  [Authorize]
  public async Task<IActionResult> Index()
  {
    string username = "Guest";
    if (User.Identity?.IsAuthenticated == true)
    {
      var usernameClaim = User.FindFirst("Username")?.Value
                       ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      if (!string.IsNullOrEmpty(usernameClaim))
      {
        username = usernameClaim;
      }
    }
    else {
      return RedirectToAction("AccessDenied", "Auth");
    }
    ViewData["Username"] = username;
    // TODO: Dynamic Content Feed Instead Of Hardcoded
    var model = await _context.FeedDataAsync(1 , 20);
    return View(model);
  }
}
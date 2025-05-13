using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TreeTalkModel.Model.Data;
using TreeTalkModel.Model.Entities;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using TreeTalk.Model.ViewModels;
using TreeTalkModel.Extensions;
using System.Globalization;

namespace TreeTalk.Controllers;

/// <summary>
/// Handles user authentication including registration, login, Google login, and logout.
/// </summary>
public class AuthController : Controller
{
  private readonly TreeTalkDbContext _context;
  private readonly JwtService _jwtService;
  private readonly ILogger _logger;

  public AuthController(TreeTalkDbContext context, JwtService jwtService, ILogger logger)
  {
    _context = context;
    _jwtService = jwtService;
    _logger = logger;
  }

  /// <summary>
  /// Displays the user registration view.
  /// </summary>
  public IActionResult Register()
  {
    return View();
  }

  /// <summary>
  /// Handles user registration.
  /// </summary>
  /// <param name="model">User registration details</param>
  /// <returns>Redirects to login on success, or redisplays form on failure</returns>
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Register(RegisterViewModel model)
  {
    _logger.LogInformation("Register attempt for email: {Email}", model.Email);
    
    if (!ModelState.IsValid){
      _logger.LogWarning("Registration model state invalid for email: {Email}", model.Email);
      return View(model);
    }

    // Validate password policy
    if (!model.Password!.VerifyPasswordPolicy(out string message))
    {
      _logger.LogWarning("Password policy violation for email: {Email}", model.Email);
      ModelState.AddModelError("Password", message);
      return View(model);
    }

    // Check if email or username already exists
    var existingUser = await _context.Users
        .FirstOrDefaultAsync(u => u.Email == model.Email || u.Username == model.Username);

    if (existingUser != null)
    {
      _logger.LogWarning("Registration failed - user with email or username already exists: {Email}", model.Email);
      ModelState.AddModelError("", "Username or Email already taken.");
      return View(model);
    }

    // Hash password and create new user
    var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

    var newUser = new User
    {
      Username = model.Username,
      Email = model.Email,
      PasswordHash = passwordHash,
      Gender = char.Parse(model.Gender!),
      Birthday = model.Birthday,
      Provider = Model.Enums.Provider.None,
      CreatedAt = DateTime.Now,
      LastLoginAt = DateTime.Now
    };

    await _context.Users.AddAsync(newUser);
    await _context.SaveChangesAsync();

    _logger.LogInformation("User registered successfully: {Email}", model.Email);
    return RedirectToAction("Login");
  }

  /// <summary>
  /// Displays the login view.
  /// </summary>
  public IActionResult Login()
  {
    return View();
  }

  /// <summary>
  /// Authenticates the user with email and password.
  /// </summary>
  /// <param name="model">Login credentials</param>
  /// <returns>Redirects to home on success, or redisplays login view on failure</returns>
  /// <summary>
  /// Handles user login requests. Validates the login credentials, signs the user in using cookie authentication,
  /// and redirects to the home page if successful.
  /// </summary>
  /// <param name="model">The login view model containing email, password, and remember-me flag.</param>
  /// <returns>Redirects to Home/Index on success, otherwise re-displays the login form with errors.</returns>
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    _logger.LogInformation("Login attempt for email: {Email}", model.Email);

    if (!ModelState.IsValid){
      _logger.LogWarning("Login model state invalid for email: {Email}", model.Email);
      return View(model);
    }
    var user = await _context.Users
        .FirstOrDefaultAsync(u => u.Email == model.Email);

    if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
    {
      _logger.LogWarning("Login failed for email: {Email}", model.Email);
      ModelState.AddModelError("", "Invalid email or password.");
      return View(model);
    }

    user.LastLoginAt = DateTime.Now;
    _context.Users.Update(user);
    await _context.SaveChangesAsync();

    var token = _jwtService.GenerateJwtToken(user.Id.ToString(), user.Email!);
    _logger.LogInformation("JWT token generated for user: {Email}", user.Email);

    // Create a list of claims for the signed-in user
    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
      new Claim(ClaimTypes.Email, user.Email!),                 
      new Claim("Username", user.Username ?? string.Empty),    
    };

    // Create a ClaimsIdentity using the cookie authentication scheme
    // think about it as digital passport in treetalk application
    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    // Define authentication properties including expiration and persistence
    var authProperties = new AuthenticationProperties
    {
      IsPersistent = model.RememberMe, // If true, keep the session alive longer
      ExpiresUtc = model.RememberMe
        ? DateTime.UtcNow.AddDays(7)   // 7 days if "Remember Me" is checked
        : DateTime.UtcNow.AddDays(1)  // Otherwise, 1 day session
    };

    // Sign the user in using the cookie authentication scheme
    await HttpContext.SignInAsync(
      CookieAuthenticationDefaults.AuthenticationScheme,
      new ClaimsPrincipal(claimsIdentity),
      authProperties
    );

    _logger.LogInformation("User signed in with email: {Email}", model.Email);
    return RedirectToAction("Index", "Home");
  }

  /// <summary>
  /// Initiates Google OAuth2 login.
  /// </summary>
  [HttpGet("Auth/GoogleLogin")]
  public IActionResult GoogleLogin()
  {
    _logger.LogInformation("Initiating Google login.");
    var redirectUrl = Url.Action(nameof(GoogleLoginCallback), "Auth");
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

    return Challenge(properties, GoogleDefaults.AuthenticationScheme);
  }

  /// <summary>
  /// Callback handler for Google login.
  /// </summary>
  /// <returns>Redirects to home on success, or login view on failure</returns>
  [HttpGet("Auth/GoogleLoginCallback")]
  public async Task<IActionResult> GoogleLoginCallback(){
    _logger.LogInformation("Google login callback hit.");
    
    var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

    if (!result.Succeeded)
    {
      _logger.LogWarning("Google authentication failed.");
      return RedirectToAction("Login", "Auth");
    }

    var email = result.Principal.FindFirstValue(ClaimTypes.Email);

    var googleId = result.Principal.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") ??
                   result.Principal.FindFirstValue("sub");

    var gender = result.Principal.FindFirstValue(ClaimTypes.Gender)?.ToLower() switch
    {
      "male" => 'M',
      "female" => 'F',
      _ => '\0'
    };

    DateTime? birthday = null;
    var birthdayClaim = result.Principal.FindFirstValue(ClaimTypes.DateOfBirth);

    if (string.IsNullOrEmpty(email)){
      _logger.LogError("Google login failed: Email not found.");
      return BadRequest("Email not found in Google");
    }

    if (string.IsNullOrEmpty(googleId)){
      _logger.LogError("Google login failed: Google ID not found.");
      return BadRequest("Google ID not found");
    }

    if (!string.IsNullOrEmpty(birthdayClaim) &&
        DateTime.TryParseExact(birthdayClaim, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
    {
      birthday = parsedDate;
    }

    var user = await _context.Users
        .FirstOrDefaultAsync(u => u.ProviderId == googleId && u.Provider == Model.Enums.Provider.Google);

    if (user == null)
    {
      user = new User
      {
        Email = email,
        Username = email.Split('@')[0],
        Provider = Model.Enums.Provider.Google,
        ProviderId = googleId,
        Gender = gender != '\0' ? gender : 'U',
        Birthday = birthday ?? DateTime.Parse("1900-01-01"),
        CreatedAt = DateTime.Now,
        LastLoginAt = DateTime.Now
      };

      await _context.Users.AddAsync(user);
      _logger.LogInformation("New Google user registered: {Email}", email);
    }
    else
    {
      user.LastLoginAt = DateTime.Now;
      _context.Users.Update(user);
      _logger.LogInformation("Returning Google user logged in: {Email}", email);
    }

    await _context.SaveChangesAsync();

    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new Claim(ClaimTypes.Email, user.Email!),
      new Claim("Username", user.Username ?? string.Empty),
    };

    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var authProperties = new AuthenticationProperties
    {
      ExpiresUtc = DateTime.UtcNow.AddHours(1)
    };

    await HttpContext.SignInAsync(
      CookieAuthenticationDefaults.AuthenticationScheme,
      new ClaimsPrincipal(claimsIdentity),
      authProperties
    );

    var token = _jwtService.GenerateJwtToken(user.Id.ToString(), user.Email!);

    var cookieOptions = new CookieOptions
    {
      HttpOnly = true,
      Secure = true,
      SameSite = SameSiteMode.Strict,
      Expires = DateTime.UtcNow.AddHours(1),
    };

    Response.Cookies.Append("auth_token", token, cookieOptions);

    _logger.LogInformation("Google login successful, JWT issued, and cookie set for: {Email}", email);
    return RedirectToAction("Index", "Home");
  }

  /// <summary>
  /// Displays the access denied view when user is not authorized.
  /// </summary>
  [HttpGet("Auth/AccessDenied")]
  public ActionResult AccessDenied()
  {
    _logger.LogWarning("Access denied page hit.");
    return View();
  }

  /// <summary>
  /// Logs out the currently authenticated user.
  /// </summary>
  /// <returns>Redirects to the login page after logout.</returns>
  [HttpPost("Logout")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Logout(){
    _logger.LogInformation("Logout initiated.");
    // sign out authenticated user 
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    // Damage auth_token section 
    if (Request.Cookies.ContainsKey("auth_token")){
      Response.Cookies.Delete("auth_token");
      _logger.LogInformation("auth_token cookie deleted.");
    }

    _logger.LogInformation("User successfully logged out.");
    return RedirectToAction("Login", "Auth");
  }
}

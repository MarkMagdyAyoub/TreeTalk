using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using TreeTalk.Settings;

/// <summary>
/// Service responsible for generating JWT tokens used for authentication.
/// </summary>
public class JwtService
{
  private readonly JwtSettings _jwtSettings;

  /// <summary>
  /// Initializes a new instance of the <see cref="JwtService"/> class.
  /// </summary>
  /// <param name="jwtSettings">JWT configuration values from appsettings.json</param>
  public JwtService(IOptions<JwtSettings> jwtSettings)
  {
    _jwtSettings = jwtSettings.Value;
  }

  /// <summary>
  /// Generates a signed JWT token for a user.
  /// </summary>
  /// <param name="userId">Unique identifier of the user (usually database ID)</param>
  /// <param name="email">User's email address</param>
  /// <param name="role">User role (default is "user")</param>
  /// <returns>A string representing the signed JWT token</returns>
  public string GenerateJwtToken(string userId, string email, string role = "user")
  {
    // Define claims included in the token
    var claims = new[]
    {
            // User Id Claim
            new Claim(JwtRegisteredClaimNames.Sub, userId),

            // Email claim
            new Claim(JwtRegisteredClaimNames.Email, email),

            // Role claim for authorization
            new Claim(ClaimTypes.Role, role),

            // Unique ID for the token (used for tracking)
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

    // Create signing key from _jwtSettings
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

    // Sign credentials (key) using HMAC-SHA256 algorithm
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    // Build the JWT token with:
    // - Issuer
    // - Audience
    // - Claims
    // - Expiration time
    // - Signing credentials
    var token = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        claims: claims,
        expires: DateTime.Now.AddHours(_jwtSettings.ExpiryHours),
        signingCredentials: creds
    );

    // Step 5: Serialize the token into a string
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
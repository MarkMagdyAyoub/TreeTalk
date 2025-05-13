namespace TreeTalkModel.Extensions
{
  public static class PasswordPolicy
  {
    /// <summary>
    /// Validates whether the given password meets the required security policy.
    /// </summary>
    /// <param name="password">The password string to validate.</param>
    /// <param name="message">
    /// When this method returns, contains a detailed message indicating 
    /// the result of the validation. If the password is valid, the message 
    /// indicates success. If invalid, it describes the specific rule that was violated.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the password meets all requirements; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The password must meet the following requirements:
    /// <list type="bullet">
    ///   <item>At least 10 characters long</item>
    ///   <item>At least 3 lowercase letters (a-z)</item>
    ///   <item>At least 3 uppercase letters (A-Z)</item>
    ///   <item>At least 2 digits (0-9)</item>
    ///   <item>At least 2 special characters from: !@#$%^&*(),.?":'{}|<></item>
    ///   <item>No whitespace or unsupported characters allowed</item>
    /// </list>
    /// </remarks>
    public static bool VerifyPasswordPolicy(this string password, out string message)
    {
      if (string.IsNullOrWhiteSpace(password))
      {
        message = "Password is required.";
        return false;
      }

      if (password.Length < 10)
      {
        message = "Password must be at least 10 characters long.";
        return false;
      }

      int lowerCount = 0, upperCount = 0, digitCount = 0, specialCount = 0;

      foreach (char c in password)
      {
        if (char.IsLower(c)) lowerCount++;
        else if (char.IsUpper(c)) upperCount++;
        else if (char.IsDigit(c)) digitCount++;
        else if ("!@#$%^&*(),.?\":'{}|<>".Contains(c)) specialCount++;
        else
        {
          message = "Password contains invalid characters.";
          return false;
        }
      }

      if (lowerCount < 3)
      {
        message = "Password must contain at least 3 lowercase letters.";
        return false;
      }

      if (upperCount < 3)
      {
        message = "Password must contain at least 3 uppercase letters.";
        return false;
      }

      if (digitCount < 2)
      {
        message = "Password must contain at least 2 digits.";
        return false;
      }

      if (specialCount < 2)
      {
        message = "Password must contain at least 2 special characters (!@#$%^&*(),.?\":'{}|<>).";
        return false;
      }

      message = "Password is valid.";
      return true;
    }
  }
}
namespace TreeTalk.Model.Entities.DTOs;

public class UpdateUserProfileRequest
{
  public int UserId { get; set; }
  public string? AboutMe { get; set; }
  public DateTime BirthDate { get; set; }
  public char Gender { get; set; } 
  public string UserProfileImageUrl { get; set; } = string.Empty;
}

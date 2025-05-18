namespace TreeTalk.Model.Entities.DTOs;
public class EditProfileRequest
{
  public IFormFile? ProfilePicture { get; set; }
  public string AboutMe { get; set; } = string.Empty;
  public char Gender { get; set; }
  public DateTime BirthDate { get; set;} 
}

namespace TreeTalk.Model.Entities.DTOs;

public class UpdateAboutMeRequest
{
  public int UserId { get; set; }
  public string AboutMe { get; set; } = string.Empty;
}

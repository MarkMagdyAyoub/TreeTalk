using TreeTalk.Model.Entities.DTOs;
using TreeTalkModel.Model.Entities.DTOs;

namespace TreeTalkModel.Model.DTOs;

public class UserProfileDto
{
  public int Id { get; set; }
  public string Username { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string? AboutMe { get; set; }
  public string UserImageUrl { get; set; } = string.Empty ;
  public DateTime BirthDate { get; set; }
  public char Gender { get; set; }
}

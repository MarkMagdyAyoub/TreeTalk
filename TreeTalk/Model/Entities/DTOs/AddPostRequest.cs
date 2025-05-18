namespace TreeTalk.Model.Entities.DTOs;
public class AddPostRequest
{
  public string Title { get; set; } = string.Empty;
  public string? Content { get; set; } 
  public IFormFile? Image { get; set; }
}

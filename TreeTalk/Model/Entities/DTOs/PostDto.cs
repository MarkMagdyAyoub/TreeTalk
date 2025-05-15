namespace TreeTalk.Model.Entities.DTOs;

public class PostDto
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public int Likes { get; set; }
  public string ImageUrl { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}
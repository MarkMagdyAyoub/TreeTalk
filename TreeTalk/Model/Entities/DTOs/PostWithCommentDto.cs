namespace TreeTalkModel.Model.Entities.DTOs;

public class PostWithCommentsDto
{
  public required PostDto Post { get; set; }
  public List<CommentTreeDto> Comments { get; set; } = new List<CommentTreeDto>();

  public class PostDto
  {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Likes { get; set; }
    public AuthorDto Author { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
  }

  public class AuthorDto
  {
    public string Username { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
  }
}
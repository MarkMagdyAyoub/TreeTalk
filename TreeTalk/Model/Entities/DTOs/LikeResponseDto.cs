namespace TreeTalk.Model.Entities.DTOs;

public class LikeResponseDto
{
  public bool Success { get; set; }
  public int LikeCount { get; set; }
  public bool Liked { get; set; }
  public string? Message { get; set; }
}

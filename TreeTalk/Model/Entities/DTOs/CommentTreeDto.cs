namespace TreeTalkModel.Model.Entities.DTOs;

public class CommentTreeDto
{
  public int CommentID { get; set; }
  public int? ParentCommentID { get; set; }
  public string Username { get; set; } = string.Empty;
  public string IndentedContent { get; set; } = string.Empty;
  public int Depth { get; set; }
  public string Path { get; set; } = string.Empty;
  public int Likes { get; set; }
  public string? ImageUrl { get; set; } = string.Empty;

  public override string ToString()
  {
    return $"[{Depth}] {Path,-10} | ID: {CommentID,-5} | Parent: {(ParentCommentID.HasValue ? ParentCommentID.Value.ToString() : "null"),-5} | {Username,-12} | Likes: {Likes,-3} | {IndentedContent}";
  }
}

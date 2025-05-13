using TreeTalkModel.Model.Entities;
namespace TreeTalk.Model.Entities;

public class CommentLike
{
  public int Id { get; set; }
  public int CommentId { get; set; }
  public int UserId { get; set; }
  public User User { get; set; } = null!;
  public Comment Comment { get; set; } = null!;
}

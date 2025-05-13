using TreeTalkModel.Model.Entities;
namespace TreeTalk.Model.Entities;

public class PostLike
{
  public int Id { get; set; }
  public int PostId { get; set; }
  public int UserId { get; set; }
  public User User { get; set; } = null!;
  public Post Post { get; set; } = null!;
}

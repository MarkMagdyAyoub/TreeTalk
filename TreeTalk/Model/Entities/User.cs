using TreeTalk.Model.Entities;
using TreeTalk.Model.Enums;

namespace TreeTalkModel.Model.Entities;

public class User
{
  public int Id { get; set; }
  public string? Username { get; set; }
  public string? Email { get; set; }
  public string? PasswordHash { get; set; }
  public DateTime Birthday { get; set; }
  public string? UserImageUrl { get; set; }
  public char Gender { get; set; }
  public string? AboutMe { get; set; }
  public bool IsBanned { get; set; }
  public bool IsDeleted { get; set; }
  public string? ProviderId { get; set; }
  public Provider Provider { get; set; }
  public DateTime LastLoginAt { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public ICollection<Post> Posts { get; set; } = new List<Post>();
  public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();
  public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

  public override string ToString()
  {
    return $@"
    User {{
      Id            = {Id,-10}
      Username        = {Username ?? "null",-20}
      Email           = {Email ?? "null",-30}
      PasswordHash    = {PasswordHash ?? "null",-60}
      Birthday        = {Birthday:yyyy-MM-dd}
      UserImageUrl    = {UserImageUrl ?? "null",-40}
      Gender          = {Gender}
      AboutMe         = {(AboutMe is null ? "null" : $"\"{AboutMe}\"")}
      ProviderId      = {ProviderId ?? "null",-30}
      Provider        = {Provider}
      IsBanned        = {IsBanned}
      IsDeleted       = {IsDeleted}
      LastLoginAt     = {LastLoginAt:yyyy-MM-dd HH:mm:ss}
      CreatedAt       = {CreatedAt:yyyy-MM-dd HH:mm:ss}
      UpdatedAt       = {(UpdatedAt.HasValue ? UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}
    }}";
  }

}

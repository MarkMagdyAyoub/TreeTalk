using TreeTalk.Model.Entities;

namespace TreeTalkModel.Model.Entities;
public class Post
{
  public int Id { get; set; }
  public int AuthorId { get; set; }
  public string? Title { get; set; }
  public string? Content { get; set; }
  public string? ImageUrl { get; set; }
  public int Likes { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public bool IsDeleted { get; set; }
  public User? User { get; set; }
  public ICollection<Comment> Comments = new List<Comment>();
  public ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

  public override string ToString()
  {
    return $@"
    Post {{
      Id         = {Id}
      AuthorId   = {AuthorId}
      Title      = {(Title is null ? "null" : $"\"{Title}\"")}
      Content    = {(Content is null ? "null" : $"\"{Content}\"")}
      ImageUrl   = {(ImageUrl is null ? "null" : $"\"{ImageUrl}\"")}
      Likes      = {Likes}
      CreatedAt  = {CreatedAt:yyyy-MM-dd HH:mm:ss}
      UpdatedAt  = {(UpdatedAt.HasValue ? UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}
      IsDeleted  = {IsDeleted}
      Username   = {(User?.Username ?? "null")}
    }}";
  }
}

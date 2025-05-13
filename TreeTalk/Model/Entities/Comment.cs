using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTalk.Model.Entities;

namespace TreeTalkModel.Model.Entities;

public class Comment
{
  public int Id { get; set; }
  public int PostId { get; set; }
  public int? ParentId { get; set; }
  public int AuthorId { get; set; }
  public string? Content { get; set; }
  public int Likes { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public bool IsDeleted { get; set; }
  public int Depth { get; set; }
  public Post? Post { get; set; }
  public User? User { get; set; }
  public Comment? Parent { get; set; }
  public ICollection<Comment>? Children { get; set; } = new List<Comment>();
  public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

  public override string ToString()
  {
    return $@"
    Comment {{
      Id         = {Id}
      PostId     = {PostId}
      ParentId   = {(ParentId.HasValue ? ParentId.Value.ToString() : "null")}
      AuthorId   = {AuthorId}
      Content    = {(Content is null ? "null" : $"\"{Content}\"")}
      Likes      = {Likes}
      CreatedAt  = {CreatedAt:yyyy-MM-dd HH:mm:ss}
      UpdatedAt  = {(UpdatedAt.HasValue ? UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null")}
      IsDeleted  = {IsDeleted}
      Depth      = {Depth}
      Username   = {(User?.Username ?? "null")}
    }}";
  }
}

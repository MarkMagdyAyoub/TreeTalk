using TreeTalkModel.Model.Entities.DTOs;

namespace TreeTalk.Model.ViewModels;

public class PostFeedViewModel
{
  public List<PostWithCommentsDto> PostsWithComments { get; set; } = new();
  public int CurrentPage { get; set; }
  public int TotalPages { get; set; }
  public int PageSize { get; set; } = 10;
}

using Microsoft.EntityFrameworkCore;

namespace TreeTalkModel.Model.Data.Extension;

public static class ContextExtensions
{
  public static void SoftDeleteCommentTree(this TreeTalkDbContext context, int commentId)
  {
    context.Database.ExecuteSqlInterpolatedAsync($"CALL soft_delete_comment_tree({commentId})");
  }
  public static async Task SoftDeleteCommentTreeAsync(this TreeTalkDbContext context, int commentId)
  {
    await context.Database.ExecuteSqlInterpolatedAsync($"CALL soft_delete_comment_tree({commentId})");
  }

  public static void SoftDeletePostAndTree(this TreeTalkDbContext context, int postId)
  {
    context.Database.ExecuteSqlInterpolatedAsync($"CALL soft_delete_post_and_tree({postId})");
  }

  public static async Task SoftDeletePostAndTreeAsync(this TreeTalkDbContext context, int postId)
  {
    await context.Database.ExecuteSqlInterpolatedAsync($"CALL soft_delete_post_and_tree({postId})");
  }
}
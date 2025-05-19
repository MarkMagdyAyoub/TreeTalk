using Microsoft.EntityFrameworkCore;
using TreeTalk.Model.Entities;
using TreeTalkModel.Model.Entities;
using TreeTalkModel.Model.Entities.DTOs;

namespace TreeTalkModel.Model.Data;

public class TreeTalkDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Post> Posts { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<CommentLike> CommentsLikes { get; set; }
  public DbSet<PostLike> PostsLikes { get; set; }

  public TreeTalkDbContext(DbContextOptions options) : base(options) { }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    var constr = config.GetSection("constr").Value;
    optionsBuilder.UseNpgsql(constr);
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(TreeTalkDbContext).Assembly);

    modelBuilder
      .HasDbFunction(
        typeof(TreeTalkDbContext)
        .GetMethod(nameof(get_comment_tree), new[] { typeof(int) } )
      );

    modelBuilder
      .HasDbFunction(
        typeof(TreeTalkDbContext)
        .GetMethod(nameof(get_comment_children), new[] { typeof(int) })
      );
    base.OnModelCreating(modelBuilder);
  }

  public IQueryable<CommentTreeDto> get_comment_tree(int postId) =>
    FromExpression(() => get_comment_tree(postId));

  public IQueryable<CommentTreeDto> get_comment_children(int commentId) =>
    FromExpression(() => get_comment_children(commentId));
}

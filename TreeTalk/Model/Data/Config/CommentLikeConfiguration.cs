using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTalk.Model.Entities;
using TreeTalkModel.Model.Data.Config;

namespace TreeTalk.Model.Data.Config;

public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLike>
{
  public void Configure(EntityTypeBuilder<CommentLike> builder)
  {
    builder.ToTable("CommentLike");

    builder.HasKey(x => x.Id);

    builder
      .Property(x => x.Id)
      .ValueGeneratedOnAdd();

    builder
      .HasOne(p => p.Comment)
      .WithMany(p => p.CommentLikes)
      .HasForeignKey(p => p.CommentId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(p => p.User)
      .WithMany(u => u.CommentLikes)
      .HasForeignKey(p => p.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasIndex(c => new {c.UserId , c.CommentId}).IsUnique();

    builder.HasData(Repository.LoadCommentLike());
  }
}

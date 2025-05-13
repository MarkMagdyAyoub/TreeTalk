using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTalk.Model.Entities;
using TreeTalkModel.Model.Data.Config;

namespace TreeTalk.Model.Data.Config;

public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
  public void Configure(EntityTypeBuilder<PostLike> builder)
  {
    builder.ToTable("PostLike");

    builder.HasKey(x => x.Id);

    builder
      .Property(x => x.Id)
      .ValueGeneratedOnAdd();

    builder
      .HasOne(p => p.Post)
      .WithMany(p => p.PostLikes)
      .HasForeignKey(p => p.PostId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(p => p.User)
      .WithMany(u => u.PostLikes)
      .HasForeignKey(p => p.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasIndex(p => new { p.UserId , p.PostId }).IsUnique();

    builder.HasData(Repository.LoadPostLike());
  }
}

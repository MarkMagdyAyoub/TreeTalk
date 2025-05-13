using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTalkModel.Model.Data.Config;
using TreeTalkModel.Model.Entities;

namespace TreeTalkModel.Model.Configurations
{
  public class PostConfiguration : IEntityTypeConfiguration<Post>
  {
    public void Configure(EntityTypeBuilder<Post> builder)
    {
      builder.ToTable("Post");

      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id)
          .ValueGeneratedOnAdd()
          .HasColumnName("Id");

      builder.Property(p => p.Title)
          .HasColumnType("VARCHAR")
          .HasMaxLength(200)
          .IsRequired();

      builder.Property(p => p.Content)
          .HasColumnType("TEXT")
          .IsRequired(false);

      builder.Property(p => p.ImageUrl)
          .HasColumnType("TEXT")
          .IsRequired(false);

      builder.Property(p => p.Likes)
          .HasDefaultValue(0)
          .IsRequired();

      builder.Property(p => p.CreatedAt)
          .HasColumnType("TIMESTAMP")
          .HasDefaultValueSql("CURRENT_TIMESTAMP")
          .IsRequired();

      builder.Property(p => p.UpdatedAt)
          .HasColumnType("TIMESTAMP")
          .IsRequired(false);

      builder.Property(p => p.IsDeleted)
          .HasDefaultValue(false)
          .IsRequired();

      builder.Property(p => p.AuthorId)
          .IsRequired();

      builder.HasOne(p => p.User)
          .WithMany(p => p.Posts)
          .HasForeignKey(p => p.AuthorId)
          .OnDelete(DeleteBehavior.Cascade);

      builder.HasData(Repository.LoadPosts());
    }
  }
}
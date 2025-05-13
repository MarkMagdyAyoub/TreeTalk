using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTalkModel.Model.Data.Config;
using TreeTalkModel.Model.Entities;

namespace TreeTalkModel.Model.Configurations
{
  public class CommentConfig : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder.ToTable("Comment");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Id)
          .ValueGeneratedOnAdd()
          .HasColumnName("Id");

      builder.Property(c => c.PostId)
          .HasColumnName("PostId")
          .IsRequired();

      builder.Property(c => c.ParentId)
          .IsRequired(false);

      builder.Property(c => c.AuthorId)
          .IsRequired();

      builder.Property(c => c.Content)
          .HasColumnType("TEXT")
          .IsRequired();

      builder.Property(c => c.Likes)
          .HasDefaultValue(0)
          .IsRequired();

      builder.Property(c => c.CreatedAt)
          .HasColumnType("TIMESTAMP")
          .HasDefaultValueSql("CURRENT_TIMESTAMP")
          .IsRequired();

      builder.Property(c => c.UpdatedAt)
          .HasColumnType("TIMESTAMP")
          .IsRequired(false);

      builder.Property(c => c.IsDeleted)
          .HasDefaultValue(false)
          .IsRequired();

      // Depth
      // Depth Between 1 and 7
      builder.Property(c => c.Depth) 
        .HasDefaultValue(0)
        .IsRequired();

      builder.HasOne(c => c.Post)
          .WithMany(p => p.Comments) 
          .HasForeignKey(c => c.PostId)
          .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(c => c.User)
          .WithMany(p => p.Comments)
          .HasForeignKey(c => c.AuthorId)
          .OnDelete(DeleteBehavior.Restrict); 

      builder.HasOne(c => c.Parent)
          .WithMany(c => c.Children)
          .HasForeignKey(c => c.ParentId)
          .OnDelete(DeleteBehavior.Cascade);

      builder.HasData(Repository.LoadComments());
    }
  }
}
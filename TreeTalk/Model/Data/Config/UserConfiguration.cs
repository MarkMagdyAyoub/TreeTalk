using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTalk.Model.Enums;
using TreeTalkModel.Model.Entities;

namespace TreeTalkModel.Model.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("User");

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName("Id");

    builder.Property(x => x.Username)
      .HasColumnType("VARCHAR")
      .HasMaxLength(50)
      .IsRequired();

    builder.Property(x => x.Email)
      .HasColumnType("VARCHAR")
      .HasMaxLength(100)
      .IsRequired();

    builder.Property(x => x.PasswordHash)
      .HasColumnType("VARCHAR")
      .HasMaxLength(60)
      .IsRequired(false);

    builder.Property(x => x.Birthday)
      .HasColumnType("DATE")
      .IsRequired();

    builder.Property(x => x.UserImageUrl)
      .HasColumnType("TEXT")
      .IsRequired(false);

    builder.Property(x => x.Gender)
      .HasColumnType("CHAR")
      .IsRequired();

    builder.Property(x => x.AboutMe)
      .HasColumnType("TEXT")
      .IsRequired(false);

    builder.Property(x => x.IsBanned)
      .HasColumnType("BOOLEAN")
      .HasDefaultValue(false)
      .IsRequired();

    builder.Property(x => x.IsDeleted)
      .HasColumnType("BOOLEAN")
      .HasDefaultValue(false)
      .IsRequired();

    builder.Property(x => x.LastLoginAt)
      .HasColumnType("TIMESTAMP")
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .IsRequired();

    builder.Property(x => x.CreatedAt)
      .HasColumnType("TIMESTAMP")
      .HasDefaultValueSql("CURRENT_TIMESTAMP")
      .IsRequired();

    builder.Property(x => x.UpdatedAt)
      .HasColumnType("TIMESTAMP")
      .IsRequired(false);

    builder.Property(x => x.Provider)
      .HasConversion(
        v => v.ToString(), // when it stores in the database (accept it as string)
        v => (Provider)Enum.Parse(typeof(Provider) , v) // when it come from the database convert it into enum
      )
      .HasMaxLength(50)
      .HasDefaultValue(Provider.None);

    builder.Property(x => x.ProviderId)
      .HasColumnType("VARCHAR")
      .HasMaxLength(100)
      .IsRequired(false);


    builder.HasIndex(x => x.Username).IsUnique();
    builder.HasIndex(x => x.Email).IsUnique();

    builder.HasData(Repository.LoadUsers());
  }
}

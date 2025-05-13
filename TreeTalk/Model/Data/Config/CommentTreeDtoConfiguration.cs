using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTalkModel.Model.Entities.DTOs;

namespace TreeTalkModel.Model.Data.Config;

public class CommentTreeDtoConfiguration : IEntityTypeConfiguration<CommentTreeDto>
{
  public void Configure(EntityTypeBuilder<CommentTreeDto> builder)
  {
    builder.HasNoKey().ToView(null);
  }
}

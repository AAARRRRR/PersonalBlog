using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Models;

namespace PersonalBlog.Data.EntityConfiguration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property("Name").IsRequired();
        builder.Property("Content").IsRequired();
        builder.Property("CreatedDate").IsRequired();
    }
}
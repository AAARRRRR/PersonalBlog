using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Models;

namespace PersonalBlog.Data.EntityConfiguration;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Title).IsRequired();
        builder.Property("Summary");
        builder.Property("Content").IsRequired();
        builder.Property("CreatedDate").IsRequired();
        builder.Property("UpdatedDate").IsRequired();
    }
}
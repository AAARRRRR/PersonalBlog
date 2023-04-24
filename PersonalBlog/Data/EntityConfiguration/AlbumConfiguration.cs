using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Models;

namespace PersonalBlog.Data.EntityConfiguration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.Name).IsUnique();
        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.UpdatedDate).IsRequired();

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Models;

namespace PersonalBlog.Data.EntityConfiguration;

public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property("PictureRoute").IsRequired();
        builder.Property("AlbumId").IsRequired();
        builder.Property("CreatedDate").IsRequired();
        builder.Property("UpdatedDate").IsRequired();
        builder.HasOne(p => p.Album)
            .WithMany()
            .HasForeignKey(p => p.AlbumId);
    }
}
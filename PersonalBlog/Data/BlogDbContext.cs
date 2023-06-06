using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.EntityConfiguration;
using PersonalBlog.Models;

namespace PersonalBlog.Data;

public class BlogDbContext : DbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    
    public BlogDbContext()
    {
    }
    
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());
    }
}
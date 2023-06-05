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
    
    // public IConfiguration _Configuration { get; }
    
    private readonly StreamWriter _logStream = new StreamWriter("../DbContext.log", append: true);

    public BlogDbContext()
    {
    }
    
    // public BlogDbContext(IConfiguration configuration)
    // {
    //     _Configuration = configuration;
    // }
    
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(_Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")).LogTo(_logStream.WriteLine).EnableDetailedErrors().EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());
    }
    
    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }

    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        await _logStream.DisposeAsync();
    }
    
}
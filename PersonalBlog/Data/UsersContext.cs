using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Authorization;

public class UsersContext : IdentityUserContext<IdentityUser>
{
    // public IConfiguration _Configuration;
    
    public UsersContext()
    {
    }
    
    // public UsersContext(IConfiguration configuration)
    // {
    //     _Configuration = configuration;
    // }
    
    public UsersContext (DbContextOptions<UsersContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(_Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
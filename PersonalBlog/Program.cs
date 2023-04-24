using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(
    options => options.UseSqlServer("Data Source=127.0.0.1,1433;" +
                                    "Initial Catalog=master;" +
                                    "User Id=sa;" +
                                    "Password=Pass@word;" +
                                    "TrustServerCertificate=True;" +
                                    "MultiSubnetFailover=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Repositories;
using PersonalBlog.Services;
using Extensions = PersonalBlog.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IArticleRepository,ArticleRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(
    options => options.UseSqlServer("Data Source=127.0.0.1,1433;" +
                                    "Initial Catalog=master;" +
                                    "User Id=sa;" +
                                    "Password=Pass@word;" +
                                    "TrustServerCertificate=True;" +
                                    "MultiSubnetFailover=True;"));
//test data seeding
Extensions.DataSeeding(builder.Services.BuildServiceProvider().GetRequiredService<BlogDbContext>());
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
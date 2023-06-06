using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using PersonalBlog.Auth;
using PersonalBlog.Authorization;
using PersonalBlog.Data;
using PersonalBlog.Repositories;
using PersonalBlog.Services;
using Extensions = PersonalBlog.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IArticleRepository,ArticleRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogDbContext>(
    options => options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"))
        .LogTo(new StreamWriter("../DbContext.log", append: true).WriteLine).EnableDetailedErrors().EnableSensitiveDataLogging());
builder.Services.AddDbContext<UsersContext>(
    options => options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));
builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UsersContext>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["X-Access-Token"];
                context.Token = token;
                return Task.CompletedTask;
            }
        };
        
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "apiWithAuthBackend",
            ValidAudience = "apiWithAuthBackend",
            IssuerSigningKey = new SymmetricSecurityKey(
                "this is my custom Secret key for authentication"u8.ToArray()
            )
        };
    });

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Email", policy => { policy.RequireClaim(ClaimTypes.Email, "jiaye.zhong@thoughtworks.com"); }
        );
    }
);


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
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
        RequestPath = "/StaticFiles"
    });

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
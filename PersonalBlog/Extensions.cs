using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Models;

namespace PersonalBlog;

public static class Extensions
{
    public static void DataSeeding(BlogDbContext blogDbContext)
    {
        var dbContext = blogDbContext;
        dbContext.Database.EnsureCreated();

        // if (!dbContext.Albums.Any())
        // {
        //     dbContext.Albums.Add(
        //         new Album { CoverPictureId = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "花" });
        //     dbContext.Albums.Add(
        //         new Album { CoverPictureId = 6, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "城市" });
        //     dbContext.Albums.Add(
        //         new Album { CoverPictureId = 8, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "建筑" });
        //     dbContext.Albums.Add(
        //         new Album { CoverPictureId = 11, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "旅行风光" });
        // }

        if (!dbContext.Articles.Any())
        {
            dbContext.Articles.Add(
                new Article
                {
                    Category = "科技", Content = File.ReadAllText("../Articles/ChatGPT.txt"), Title = "ChatGPT",
                    IsDisplay = true, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "开发", Content = File.ReadAllText("../Articles/EFcore使用贴士.txt"), Title = "EFcore使用贴士",
                    IsDisplay = true, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "开发", Content = File.ReadAllText("../Articles/后端开发.txt"), Title = "后端开发",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "开发", Content = File.ReadAllText("../Articles/软件开发.txt"), Title = "软件开发",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "生活", Content = File.ReadAllText("../Articles/如何度过周末.txt"), Title = "如何度过周末",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "生活", Content = File.ReadAllText("../Articles/如何拍摄出好的摄影作品.txt"), Title = "如何拍摄出好的摄影作品",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "阅读", Content = File.ReadAllText("../Articles/巴金.txt"), Title = "巴金",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "阅读", Content = File.ReadAllText("../Articles/老舍.txt"), Title = "老舍",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "阅读", Content = File.ReadAllText("../Articles/鲁迅.txt"), Title = "鲁迅",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "城市", Content = File.ReadAllText("../Articles/北京.txt"), Title = "北京",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "美食", Content = File.ReadAllText("../Articles/西安.txt"), Title = "西安",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "美食", Content = File.ReadAllText("../Articles/中国美食.txt"), Title = "中国美食",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
            dbContext.Articles.Add(
                new Article
                {
                    Category = "美食", Content = File.ReadAllText("../Articles/泰国美食.txt"), Title = "泰国美食",
                    IsDisplay = false, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                });
        }

        if (!dbContext.Pictures.Any())
        {
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "夜华一", PictureRoute = "Images/夜华一.jpg", Description = "", AlbumId = 9,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = true
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "夜华二", PictureRoute = "Images/夜华二.jpg", Description = "", AlbumId = 9,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "夜华三", PictureRoute = "Images/夜华三.png", Description = "", AlbumId = 9,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "夜华夜华夜华夜华夜华夜华夜华夜华", PictureRoute = "Images/夜华夜华夜华夜华夜华夜华夜华夜华.jpg", Description = "", AlbumId = 9,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "落华", PictureRoute = "Images/落华.jpg", Description = "", AlbumId = 9,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = true
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "落华2", PictureRoute = "Images/落华.png", Description = "", AlbumId = 9,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "waiting", PictureRoute = "Images/waiting.jpg", Description = "", AlbumId = 10,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = true
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "好戏登场", PictureRoute = "Images/好戏登场.jpg", Description = "", AlbumId = 10,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "Form", PictureRoute = "Images/Form.jpg", Description = "", AlbumId = 11,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "Form2", PictureRoute = "Images/Form2.jpg", Description = "", AlbumId = 11,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "建筑", PictureRoute = "Images/建筑.jpg", Description = "", AlbumId = 11,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = false
                });
            dbContext.Pictures.Add(
                new Picture
                {
                    Name = "日照金山", PictureRoute = "Images/日照金山.jpg", Description = "", AlbumId = 12,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDisplay = true
                });
        }

        if (!dbContext.Comments.Any())
        {
            dbContext.Comments.Add(
                new Comment
                {
                    Name = "Avan", Contact = "12345678", Content = "interesting", CreatedDate = DateTime.Now,
                    IsDisplay = true
                });
            dbContext.Comments.Add(
                new Comment
                {
                    Name = "Becca", Contact = "12345689", 
                    Content = "interesting\n" +
                              "interesting\n" +
                              "interesting\n" +
                              "interesting\n" +
                              "interesting\n" + 
                              "interesting\n",
                    CreatedDate = DateTime.Now,
                    IsDisplay = true
                });
            dbContext.Comments.Add(
                new Comment
                {
                    Name = "Caroline", Contact = "3234214142", Content = "interesting有趣", CreatedDate = DateTime.Now,
                    IsDisplay = true
                });
        }

        dbContext.SaveChanges();
    }
}
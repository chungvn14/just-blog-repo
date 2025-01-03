using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FA.JustBlog.Core.Data
{
    public static class JustBlogInitializer
    {
        public static void Seeding(this ModelBuilder modelBuilder)
        {
            // Seed data for Categories  
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Technology", UrlSlug = "technology", Description = "Posts about technology topics." },
                new Category { Id = 2, Name = "Health", UrlSlug = "health", Description = "Articles related to health." },
                new Category { Id = 3, Name = "Lifestyle", UrlSlug = "lifestyle", Description = "Content about lifestyle and leisure." }
            );

            // Seed data for Tags  
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "ASP.NET", UrlSlug = "aspnet", Description = "All about ASP.NET development.", Count = 30 },
                new Tag { Id = 2, Name = "C#", UrlSlug = "csharp", Description = "C# programming language tutorials.", Count = 18 },
                new Tag { Id = 3, Name = "Wellness", UrlSlug = "wellness", Description = "Tips for a balanced lifestyle.", Count = 2 }
            );

            // Seed data for Posts  
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Getting started with ASP.NET Core",
                    ShortDescription = "A brief overview of ASP.NET Core.",
                    PostContent = "This post discusses the basics of ASP.NET Core development. ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, connected applications.",
                    UrlSlug = "getting-started-aspnet-core",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddDays(-7), // Published 7 days ago
                    Modified = DateTime.UtcNow,
                    CategoryId = 1, // Linking to the Technology category
                    ViewCount = 150,
                    RateCount = 10,
                    TotalRate = 45
                },
                new Post
                {
                    Id = 2,
                    Title = "Understanding C# Generics",
                    ShortDescription = "Deep dive into generics in C#.",
                    PostContent = "Generics in C# allow you to define a class or method with a placeholder for the type of data it stores or manipulates. In this post, we explore their usage, benefits, and limitations.",
                    UrlSlug = "understanding-csharp-generics",
                    Published = false,
                    PostedOn = DateTime.UtcNow.AddDays(-5), // Published 5 days ago
                    Modified = DateTime.UtcNow,
                    CategoryId = 1, // Linking to the Technology category
                    ViewCount = 80,
                    RateCount = 5,
                    TotalRate = 25
                },
                new Post
                {
                    Id = 3,
                    Title = "Tips for a Healthy Lifestyle",
                    ShortDescription = "Simple habits to improve your health.",
                    PostContent = "In this post, we explore easy ways to stay healthy and active, including simple habits that can make a huge difference to your health and well-being.",
                    UrlSlug = "healthy-lifestyle-tips",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddDays(-3), // Published 3 days ago
                    Modified = DateTime.UtcNow,
                    CategoryId = 2, // Linking to the Health category
                    ViewCount = 120,
                    RateCount = 8,
                    TotalRate = 32
                },
                new Post
                {
                    Id = 4,
                    Title = "Mastering EF Core",
                    ShortDescription = "A complete guide to learn EF Core.",
                    PostContent = "In this post, we explore Entity Framework Core and how to use it effectively in modern .NET applications.",
                    UrlSlug = "mastering-ef-core",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddDays(-1),
                    Modified = DateTime.UtcNow,
                    CategoryId = 2, // Linking to the Health category
                    ViewCount = 120,
                    RateCount = 8,
                    TotalRate = 32
                },
                new Post
                {
                    Id = 5,
                    Title = "Mastering ASP.NET Core",
                    ShortDescription = "A complete guide to learn ASP.NET Core.",
                    PostContent = "This comprehensive guide covers everything you need to know to start building robust web applications using ASP.NET Core, from setup to deployment.",
                    UrlSlug = "mastering-aspnet-core",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddHours(-2),
                    Modified = DateTime.UtcNow,
                    CategoryId = 1, // Linking to the Technology category
                    ViewCount = 300,
                    RateCount = 15,
                    TotalRate = 75
                },
                new Post
                {
                    Id = 6,
                    Title = "Top 5 Travel Destinations for 2024",
                    ShortDescription = "Explore the best places to visit in 2024.",
                    PostContent = "From stunning beaches to cultural landmarks, discover the top five travel destinations for 2024 and plan your next adventure.",
                    UrlSlug = "top-5-travel-destinations-2024",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddMinutes(-5),
                    Modified = DateTime.UtcNow,
                    CategoryId = 3, // Linking to the Lifestyle category
                    ViewCount = 500,
                    RateCount = 20,
                    TotalRate = 90
                },
                new Post
                {
                    Id = 7,
                    Title = "10 Delicious Vegan Recipes",
                    ShortDescription = "Easy and healthy vegan recipes to try.",
                    PostContent = "This post shares ten delicious vegan recipes that are easy to make and packed with flavor. Perfect for anyone looking to explore plant-based meals.",
                    UrlSlug = "10-delicious-vegan-recipes",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddDays(-5),
                    Modified = DateTime.UtcNow,
                    CategoryId = 3, // Linking to the Lifestyle category
                    ViewCount = 200,
                    RateCount = 10,
                    TotalRate = 50
                },
                new Post
                {
                    Id = 8,
                    Title = "The Future of AI in Healthcare",
                    ShortDescription = "How AI is transforming the healthcare industry.",
                    PostContent = "Artificial intelligence is reshaping healthcare. This post explores the latest advancements and the potential impact AI could have on patient care and medical research.",
                    UrlSlug = "future-of-ai-in-healthcare",
                    Published = true,
                    PostedOn = DateTime.UtcNow.AddDays(-7),
                    Modified = DateTime.UtcNow,
                    CategoryId = 1, // Linking to the Technology category
                    ViewCount = 450,
                    RateCount = 18,
                    TotalRate = 85
                }
            );

            // Seed data for PostTagMap  
            modelBuilder.Entity<PostTagMap>().HasData(
                new PostTagMap { PostId = 1, TagId = 1 },
                new PostTagMap { PostId = 1, TagId = 2 },
                new PostTagMap { PostId = 2, TagId = 2 },
                new PostTagMap { PostId = 2, TagId = 1 },
                new PostTagMap { PostId = 3, TagId = 3 }
            );

            // Seed data for Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    PostId = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    CommentHeader = "Great post on technology!",
                    CommentText = "I really enjoyed reading this article. Keep up the great work!",
                    CommentTime = DateTime.Now.AddDays(-2)
                },
                new Comment
                {
                    Id = 2,
                    PostId = 1,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    CommentHeader = "Amazing insights",
                    CommentText = "This is exactly what I was looking for, thank you!",
                    CommentTime = DateTime.Now.AddDays(-1)
                },
                new Comment
                {
                    Id = 3,
                    PostId = 2,
                    Name = "Mark Lee",
                    Email = "mark.lee@example.com",
                    CommentHeader = "Very helpful health tips",
                    CommentText = "I found these health tips to be quite helpful. Thanks for sharing!",
                    CommentTime = DateTime.Now.AddDays(-3)
                }
            );
        }
    }
}

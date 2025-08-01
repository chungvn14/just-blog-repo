﻿// <auto-generated />
using System;
using FA.JustBlog.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    [DbContext(typeof(JustBlogContext))]
    [Migration("20241229060514_add_user")]
    partial class add_user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FA.JustBlog.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Posts about technology topics.",
                            Name = "Technology",
                            UrlSlug = "technology"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Articles related to health.",
                            Name = "Health",
                            UrlSlug = "health"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Content about lifestyle and leisure.",
                            Name = "Lifestyle",
                            UrlSlug = "lifestyle"
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentHeader")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CommentTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentHeader = "Great post on technology!",
                            CommentText = "I really enjoyed reading this article. Keep up the great work!",
                            CommentTime = new DateTime(2024, 12, 27, 13, 5, 13, 363, DateTimeKind.Local).AddTicks(2875),
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommentHeader = "Amazing insights",
                            CommentText = "This is exactly what I was looking for, thank you!",
                            CommentTime = new DateTime(2024, 12, 28, 13, 5, 13, 363, DateTimeKind.Local).AddTicks(2888),
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            PostId = 1
                        },
                        new
                        {
                            Id = 3,
                            CommentHeader = "Very helpful health tips",
                            CommentText = "I found these health tips to be quite helpful. Thanks for sharing!",
                            CommentTime = new DateTime(2024, 12, 26, 13, 5, 13, 363, DateTimeKind.Local).AddTicks(2890),
                            Email = "mark.lee@example.com",
                            Name = "Mark Lee",
                            PostId = 2
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Published")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("RateCount")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TotalRate")
                        .HasColumnType("int");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2805),
                            PostContent = "This post discusses the basics of ASP.NET Core development. ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, connected applications.",
                            PostedOn = new DateTime(2024, 12, 22, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2794),
                            Published = true,
                            RateCount = 10,
                            ShortDescription = "A brief overview of ASP.NET Core.",
                            Title = "Getting started with ASP.NET Core",
                            TotalRate = 45,
                            UrlSlug = "getting-started-aspnet-core",
                            ViewCount = 150
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2808),
                            PostContent = "Generics in C# allow you to define a class or method with a placeholder for the type of data it stores or manipulates. In this post, we explore their usage, benefits, and limitations.",
                            PostedOn = new DateTime(2024, 12, 24, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2808),
                            Published = false,
                            RateCount = 5,
                            ShortDescription = "Deep dive into generics in C#.",
                            Title = "Understanding C# Generics",
                            TotalRate = 25,
                            UrlSlug = "understanding-csharp-generics",
                            ViewCount = 80
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2812),
                            PostContent = "In this post, we explore easy ways to stay healthy and active, including simple habits that can make a huge difference to your health and well-being.",
                            PostedOn = new DateTime(2024, 12, 26, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2811),
                            Published = true,
                            RateCount = 8,
                            ShortDescription = "Simple habits to improve your health.",
                            Title = "Tips for a Healthy Lifestyle",
                            TotalRate = 32,
                            UrlSlug = "healthy-lifestyle-tips",
                            ViewCount = 120
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2814),
                            PostContent = "In this post, we explore Entity Framework Core and how to use it effectively in modern .NET applications.",
                            PostedOn = new DateTime(2024, 12, 28, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2814),
                            Published = true,
                            RateCount = 8,
                            ShortDescription = "A complete guide to learn EF Core.",
                            Title = "Mastering EF Core",
                            TotalRate = 32,
                            UrlSlug = "mastering-ef-core",
                            ViewCount = 120
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2816),
                            PostContent = "This comprehensive guide covers everything you need to know to start building robust web applications using ASP.NET Core, from setup to deployment.",
                            PostedOn = new DateTime(2024, 12, 29, 4, 5, 13, 363, DateTimeKind.Utc).AddTicks(2816),
                            Published = true,
                            RateCount = 15,
                            ShortDescription = "A complete guide to learn ASP.NET Core.",
                            Title = "Mastering ASP.NET Core",
                            TotalRate = 75,
                            UrlSlug = "mastering-aspnet-core",
                            ViewCount = 300
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2820),
                            PostContent = "From stunning beaches to cultural landmarks, discover the top five travel destinations for 2024 and plan your next adventure.",
                            PostedOn = new DateTime(2024, 12, 29, 6, 0, 13, 363, DateTimeKind.Utc).AddTicks(2818),
                            Published = true,
                            RateCount = 20,
                            ShortDescription = "Explore the best places to visit in 2024.",
                            Title = "Top 5 Travel Destinations for 2024",
                            TotalRate = 90,
                            UrlSlug = "top-5-travel-destinations-2024",
                            ViewCount = 500
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2823),
                            PostContent = "This post shares ten delicious vegan recipes that are easy to make and packed with flavor. Perfect for anyone looking to explore plant-based meals.",
                            PostedOn = new DateTime(2024, 12, 24, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2822),
                            Published = true,
                            RateCount = 10,
                            ShortDescription = "Easy and healthy vegan recipes to try.",
                            Title = "10 Delicious Vegan Recipes",
                            TotalRate = 50,
                            UrlSlug = "10-delicious-vegan-recipes",
                            ViewCount = 200
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2825),
                            PostContent = "Artificial intelligence is reshaping healthcare. This post explores the latest advancements and the potential impact AI could have on patient care and medical research.",
                            PostedOn = new DateTime(2024, 12, 22, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2824),
                            Published = true,
                            RateCount = 18,
                            ShortDescription = "How AI is transforming the healthcare industry.",
                            Title = "The Future of AI in Healthcare",
                            TotalRate = 85,
                            UrlSlug = "future-of-ai-in-healthcare",
                            ViewCount = 450
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.PostTagMap", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTagMaps");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            TagId = 1
                        },
                        new
                        {
                            PostId = 1,
                            TagId = 2
                        },
                        new
                        {
                            PostId = 2,
                            TagId = 2
                        },
                        new
                        {
                            PostId = 2,
                            TagId = 1
                        },
                        new
                        {
                            PostId = 3,
                            TagId = 3
                        });
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 30,
                            Description = "All about ASP.NET development.",
                            Name = "ASP.NET",
                            UrlSlug = "aspnet"
                        },
                        new
                        {
                            Id = 2,
                            Count = 18,
                            Description = "C# programming language tutorials.",
                            Name = "C#",
                            UrlSlug = "csharp"
                        },
                        new
                        {
                            Id = 3,
                            Count = 2,
                            Description = "Tips for a balanced lifestyle.",
                            Name = "Wellness",
                            UrlSlug = "wellness"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Comment", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.PostTagMap", b =>
                {
                    b.HasOne("FA.JustBlog.Core.Models.Post", "Post")
                        .WithMany("PostTagMaps")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FA.JustBlog.Core.Models.Tag", "Tag")
                        .WithMany("PostTagMaps")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostTagMaps");
                });

            modelBuilder.Entity("FA.JustBlog.Core.Models.Tag", b =>
                {
                    b.Navigation("PostTagMaps");
                });
#pragma warning restore 612, 618
        }
    }
}

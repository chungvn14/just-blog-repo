using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PostContent = table.Column<string>(type: "ntext", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CommentText = table.Column<string>(type: "text", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Posts about technology topics.", "Technology", "technology" },
                    { 2, "Articles related to health.", "Health", "health" },
                    { 3, "Content about lifestyle and leisure.", "Lifestyle", "lifestyle" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 30, "All about ASP.NET development.", "ASP.NET", "aspnet" },
                    { 2, 18, "C# programming language tutorials.", "C#", "csharp" },
                    { 3, 2, "Tips for a balanced lifestyle.", "Wellness", "wellness" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { 1, 1, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7457), "This post discusses the basics of ASP.NET Core development. ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, connected applications.", new DateTime(2024, 12, 20, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7452), true, 10, "A brief overview of ASP.NET Core.", "Getting started with ASP.NET Core", 45, "getting-started-aspnet-core", 150 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { 2, 1, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7463), "Generics in C# allow you to define a class or method with a placeholder for the type of data it stores or manipulates. In this post, we explore their usage, benefits, and limitations.", new DateTime(2024, 12, 22, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7463), 5, "Deep dive into generics in C#.", "Understanding C# Generics", 25, "understanding-csharp-generics", 80 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7467), "In this post, we explore easy ways to stay healthy and active, including simple habits that can make a huge difference to your health and well-being.", new DateTime(2024, 12, 24, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7466), true, 8, "Simple habits to improve your health.", "Tips for a Healthy Lifestyle", 32, "healthy-lifestyle-tips", 120 },
                    { 4, 2, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7469), "In this post, we explore Entity Framework Core and how to use it effectively in modern .NET applications.", new DateTime(2024, 12, 26, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7469), true, 8, "A complete guide to learn EF Core.", "Mastering EF Core", 32, "mastering-ef-core", 120 },
                    { 5, 1, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7472), "This comprehensive guide covers everything you need to know to start building robust web applications using ASP.NET Core, from setup to deployment.", new DateTime(2024, 12, 27, 10, 48, 13, 503, DateTimeKind.Utc).AddTicks(7471), true, 15, "A complete guide to learn ASP.NET Core.", "Mastering ASP.NET Core", 75, "mastering-aspnet-core", 300 },
                    { 6, 3, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7476), "From stunning beaches to cultural landmarks, discover the top five travel destinations for 2024 and plan your next adventure.", new DateTime(2024, 12, 27, 12, 43, 13, 503, DateTimeKind.Utc).AddTicks(7474), true, 20, "Explore the best places to visit in 2024.", "Top 5 Travel Destinations for 2024", 90, "top-5-travel-destinations-2024", 500 },
                    { 7, 3, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7478), "This post shares ten delicious vegan recipes that are easy to make and packed with flavor. Perfect for anyone looking to explore plant-based meals.", new DateTime(2024, 12, 22, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7477), true, 10, "Easy and healthy vegan recipes to try.", "10 Delicious Vegan Recipes", 50, "10-delicious-vegan-recipes", 200 },
                    { 8, 1, new DateTime(2024, 12, 27, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7480), "Artificial intelligence is reshaping healthcare. This post explores the latest advancements and the potential impact AI could have on patient care and medical research.", new DateTime(2024, 12, 20, 12, 48, 13, 503, DateTimeKind.Utc).AddTicks(7480), true, 18, "How AI is transforming the healthcare industry.", "The Future of AI in Healthcare", 85, "future-of-ai-in-healthcare", 450 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Great post on technology!", "I really enjoyed reading this article. Keep up the great work!", new DateTime(2024, 12, 25, 19, 48, 13, 503, DateTimeKind.Local).AddTicks(7526), "john.doe@example.com", "John Doe", 1 },
                    { 2, "Amazing insights", "This is exactly what I was looking for, thank you!", new DateTime(2024, 12, 26, 19, 48, 13, 503, DateTimeKind.Local).AddTicks(7539), "jane.smith@example.com", "Jane Smith", 1 },
                    { 3, "Very helpful health tips", "I found these health tips to be quite helpful. Thanks for sharing!", new DateTime(2024, 12, 24, 19, 48, 13, 503, DateTimeKind.Local).AddTicks(7541), "mark.lee@example.com", "Mark Lee", 2 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

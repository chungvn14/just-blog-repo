using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class _09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2024, 12, 27, 13, 34, 41, 744, DateTimeKind.Local).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2024, 12, 28, 13, 34, 41, 744, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2024, 12, 26, 13, 34, 41, 744, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(905), new DateTime(2024, 12, 22, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(909), new DateTime(2024, 12, 24, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(912), new DateTime(2024, 12, 26, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(911) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(914), new DateTime(2024, 12, 28, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(913) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(916), new DateTime(2024, 12, 29, 4, 34, 41, 744, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(919), new DateTime(2024, 12, 29, 6, 29, 41, 744, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(921), new DateTime(2024, 12, 24, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(923), new DateTime(2024, 12, 22, 6, 34, 41, 744, DateTimeKind.Utc).AddTicks(923) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2024, 12, 27, 13, 5, 13, 363, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2024, 12, 28, 13, 5, 13, 363, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2024, 12, 26, 13, 5, 13, 363, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2805), new DateTime(2024, 12, 22, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2808), new DateTime(2024, 12, 24, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2808) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2812), new DateTime(2024, 12, 26, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2814), new DateTime(2024, 12, 28, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2816), new DateTime(2024, 12, 29, 4, 5, 13, 363, DateTimeKind.Utc).AddTicks(2816) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2820), new DateTime(2024, 12, 29, 6, 0, 13, 363, DateTimeKind.Utc).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2823), new DateTime(2024, 12, 24, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2825), new DateTime(2024, 12, 22, 6, 5, 13, 363, DateTimeKind.Utc).AddTicks(2824) });
        }
    }
}

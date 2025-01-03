using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class add_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2024, 12, 27, 7, 45, 51, 706, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2024, 12, 28, 7, 45, 51, 706, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2024, 12, 26, 7, 45, 51, 706, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4839), new DateTime(2024, 12, 22, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4844), new DateTime(2024, 12, 24, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4843) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4853), new DateTime(2024, 12, 26, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4856), new DateTime(2024, 12, 28, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4859), new DateTime(2024, 12, 28, 22, 45, 51, 706, DateTimeKind.Utc).AddTicks(4858) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4863), new DateTime(2024, 12, 29, 0, 40, 51, 706, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4865), new DateTime(2024, 12, 24, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4868), new DateTime(2024, 12, 22, 0, 45, 51, 706, DateTimeKind.Utc).AddTicks(4867) });
        }
    }
}

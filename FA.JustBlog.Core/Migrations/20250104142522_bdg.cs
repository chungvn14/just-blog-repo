using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class bdg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2025, 1, 2, 21, 25, 21, 971, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2025, 1, 3, 21, 25, 21, 971, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2025, 1, 1, 21, 25, 21, 971, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6194), new DateTime(2024, 12, 28, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6188) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6197), new DateTime(2024, 12, 30, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6199), new DateTime(2025, 1, 1, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6202), new DateTime(2025, 1, 3, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6202) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6204), new DateTime(2025, 1, 4, 12, 25, 21, 971, DateTimeKind.Utc).AddTicks(6204) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 1, 4, 14, 20, 21, 971, DateTimeKind.Utc).AddTicks(6206) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6209), new DateTime(2024, 12, 30, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6209) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6212), new DateTime(2024, 12, 28, 14, 25, 21, 971, DateTimeKind.Utc).AddTicks(6211) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2024, 12, 27, 16, 31, 29, 812, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2024, 12, 28, 16, 31, 29, 812, DateTimeKind.Local).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2024, 12, 26, 16, 31, 29, 812, DateTimeKind.Local).AddTicks(944));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(807), new DateTime(2024, 12, 22, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(797) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(811), new DateTime(2024, 12, 24, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(813), new DateTime(2024, 12, 26, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(812) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(815), new DateTime(2024, 12, 28, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(817), new DateTime(2024, 12, 29, 7, 31, 29, 812, DateTimeKind.Utc).AddTicks(817) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(821), new DateTime(2024, 12, 29, 9, 26, 29, 812, DateTimeKind.Utc).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(823), new DateTime(2024, 12, 24, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(825), new DateTime(2024, 12, 22, 9, 31, 29, 812, DateTimeKind.Utc).AddTicks(824) });
        }
    }
}

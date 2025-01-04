using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class bttu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentTime",
                value: new DateTime(2025, 1, 2, 21, 34, 34, 387, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommentTime",
                value: new DateTime(2025, 1, 3, 21, 34, 34, 387, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommentTime",
                value: new DateTime(2025, 1, 1, 21, 34, 34, 387, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6354), new DateTime(2024, 12, 28, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6347) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6357), new DateTime(2024, 12, 30, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6360), new DateTime(2025, 1, 1, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6359) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6362), new DateTime(2025, 1, 3, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6361) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6365), new DateTime(2025, 1, 4, 12, 34, 34, 387, DateTimeKind.Utc).AddTicks(6365) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6368), new DateTime(2025, 1, 4, 14, 29, 34, 387, DateTimeKind.Utc).AddTicks(6367) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6370), new DateTime(2024, 12, 30, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Modified", "PostedOn" },
                values: new object[] { new DateTime(2025, 1, 4, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6372), new DateTime(2024, 12, 28, 14, 34, 34, 387, DateTimeKind.Utc).AddTicks(6372) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

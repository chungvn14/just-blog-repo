using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class dfr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

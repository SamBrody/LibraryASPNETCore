using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrasturcture.Migrations
{
    public partial class initLasVerDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book_",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReaderId", "ShelfId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Book_",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReaderId", "ShelfId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book_",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReaderId", "ShelfId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Book_",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReaderId", "ShelfId" },
                values: new object[] { 2, 1 });
        }
    }
}

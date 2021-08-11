using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrasturcture.Migrations
{
    public partial class addData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author_",
                columns: new[] { "Id", "BirthDate", "FullName" },
                values: new object[] { 1, new DateTime(1962, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дэвид Фостер" });

            migrationBuilder.InsertData(
                table: "Author_",
                columns: new[] { "Id", "BirthDate", "FullName" },
                values: new object[] { 2, new DateTime(1818, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван Сергеевич Тургенев" });

            migrationBuilder.InsertData(
                table: "Book_",
                columns: new[] { "Id", "PhotoPath", "ReaderId", "ShelfId", "TakeDate", "Title" },
                values: new object[] { 2, "mymy.jpg", 2, 1, new DateTime(2021, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Муму" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author_",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author_",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book_",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

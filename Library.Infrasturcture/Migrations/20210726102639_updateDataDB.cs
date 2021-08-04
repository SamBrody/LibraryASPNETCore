using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryASPNET_Core.Migrations
{
    public partial class updateDataDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories_",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Детектив" },
                    { 2, "Фантастика" },
                    { 3, "Фэнтези" },
                    { 4, "Приключения" },
                    { 5, "История" }
                });

            migrationBuilder.InsertData(
                table: "Readers_",
                columns: new[] { "Id", "BirthDate", "First_Name", "Last_Name", "Patronymic", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванов", "Иванович", new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1992, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петр", "Квашнин", "Михайлович", new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2001, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Александр", "Петрухин", "Андреевич", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Books_",
                columns: new[] { "Id", "PhotoPath", "Reader_Id", "Shelf_Id", "TakeDate", "Title" },
                values: new object[] { 1, "C:\\Users\\semyo\\Desktop\\images\\1", 1, 1, new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бесконечная шутка" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books_",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories_",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories_",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories_",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories_",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories_",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

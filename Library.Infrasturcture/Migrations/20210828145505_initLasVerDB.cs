using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrasturcture.Migrations
{
    public partial class initLasVerDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { new DateTime(1996, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иванов Иван Иванович", new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { new DateTime(1992, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Квашнин Петр Михайлович", new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reader_",
                columns: new[] { "Id", "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { 4, new DateTime(2001, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петрухин Александр Андреевич", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "-");

            migrationBuilder.UpdateData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "B");

            migrationBuilder.InsertData(
                table: "Shelf_",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { new DateTime(1996, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иванов Иван Иванович", new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { new DateTime(1992, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Квашнин Петр Михайлович", new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reader_",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "FullName", "RegistrationDate" },
                values: new object[] { new DateTime(2001, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петрухин Александр Андреевич", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "B");

            migrationBuilder.UpdateData(
                table: "Shelf_",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "C");
        }
    }
}

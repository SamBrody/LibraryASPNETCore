using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrasturcture.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Author_Book_",
                columns: new[] { "AuthorId", "BookId", "Id" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Book_Category_",
                columns: new[] { "BookId", "CategoryId", "Id" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 1, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Book_Tag_",
                columns: new[] { "BookId", "TagId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 3, 2 },
                    { 2, 1, 3 },
                    { 2, 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Рассказ");

            migrationBuilder.UpdateData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Роман");

            migrationBuilder.UpdateData(
                table: "Tag_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "#люди");

            migrationBuilder.UpdateData(
                table: "Tag_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "#собака");

            migrationBuilder.UpdateData(
                table: "Tag_",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "#постмодерн");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author_Book_",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Author_Book_",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Book_Category_",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Book_Category_",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Book_Tag_",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Book_Tag_",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Book_Tag_",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Book_Tag_",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Детектив");

            migrationBuilder.UpdateData(
                table: "Category_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Фантастика");

            migrationBuilder.InsertData(
                table: "Category_",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Фэнтези" },
                    { 4, "Приключения" },
                    { 5, "История" }
                });

            migrationBuilder.UpdateData(
                table: "Tag_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "#war");

            migrationBuilder.UpdateData(
                table: "Tag_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "#love");

            migrationBuilder.UpdateData(
                table: "Tag_",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "#KILLA");
        }
    }
}

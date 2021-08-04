using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryASPNET_Core.Migrations
{
    public partial class updatephoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books_",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "infjoke.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books_",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "C:\\Users\\semyo\\Desktop\\images\\1");
        }
    }
}

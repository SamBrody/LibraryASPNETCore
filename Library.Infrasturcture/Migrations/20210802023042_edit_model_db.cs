using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryASPNET_Core.Migrations
{
    public partial class edit_model_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Readers_");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Readers_");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Readers_");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Authors_");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Authors_");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Authors_");

            migrationBuilder.AddColumn<string>(
                name: "Full_Name",
                table: "Readers_",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Full_Name",
                table: "Authors_",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Full_Name",
                value: "Иванов Иван Иванович");

            migrationBuilder.UpdateData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Full_Name",
                value: "Квашнин Петр Михайлович");

            migrationBuilder.UpdateData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 3,
                column: "Full_Name",
                value: "Петрухин Александр Андреевич");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Full_Name",
                table: "Readers_");

            migrationBuilder.DropColumn(
                name: "Full_Name",
                table: "Authors_");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Readers_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Readers_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Readers_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Authors_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Authors_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Authors_",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "First_Name", "Last_Name", "Patronymic" },
                values: new object[] { "Иван", "Иванов", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "First_Name", "Last_Name", "Patronymic" },
                values: new object[] { "Петр", "Квашнин", "Михайлович" });

            migrationBuilder.UpdateData(
                table: "Readers_",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "First_Name", "Last_Name", "Patronymic" },
                values: new object[] { "Александр", "Петрухин", "Андреевич" });
        }
    }
}

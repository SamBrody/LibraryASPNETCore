using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryASPNET_Core.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readers_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelves_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shelf_Id = table.Column<int>(type: "int", nullable: false),
                    Reader_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books__Readers__Reader_Id",
                        column: x => x.Reader_Id,
                        principalTable: "Readers_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books__Shelves__Shelf_Id",
                        column: x => x.Shelf_Id,
                        principalTable: "Shelves_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors_Books_",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_Books_", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_Authors_Books__Authors__Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Books__Books__Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books_Categories_",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_Categories_", x => new { x.Book_Id, x.Category_Id });
                    table.ForeignKey(
                        name: "FK_Books_Categories__Books__Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories__Categories__Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books_Tags_",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Tag_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_Tags_", x => new { x.Book_Id, x.Tag_Id });
                    table.ForeignKey(
                        name: "FK_Books_Tags__Books__Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Tags__Tags__Tag_Id",
                        column: x => x.Tag_Id,
                        principalTable: "Tags_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shelves_",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" }
                });

            migrationBuilder.InsertData(
                table: "Tags_",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "#war" },
                    { 2, "#love" },
                    { 3, "#KILLA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Books__Author_Id",
                table: "Authors_Books_",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books__Reader_Id",
                table: "Books_",
                column: "Reader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books__Shelf_Id",
                table: "Books_",
                column: "Shelf_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categories__Category_Id",
                table: "Books_Categories_",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Tags__Tag_Id",
                table: "Books_Tags_",
                column: "Tag_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors_Books_");

            migrationBuilder.DropTable(
                name: "Books_Categories_");

            migrationBuilder.DropTable(
                name: "Books_Tags_");

            migrationBuilder.DropTable(
                name: "Authors_");

            migrationBuilder.DropTable(
                name: "Categories_");

            migrationBuilder.DropTable(
                name: "Books_");

            migrationBuilder.DropTable(
                name: "Tags_");

            migrationBuilder.DropTable(
                name: "Readers_");

            migrationBuilder.DropTable(
                name: "Shelves_");
        }
    }
}

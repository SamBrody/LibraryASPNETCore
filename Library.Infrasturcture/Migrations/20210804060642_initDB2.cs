using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryASPNET_Core.Migrations
{
    public partial class initDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Author_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reader_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelf_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book_",
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
                    table.PrimaryKey("PK_Book_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book__Reader__Reader_Id",
                        column: x => x.Reader_Id,
                        principalTable: "Reader_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book__Shelf__Shelf_Id",
                        column: x => x.Shelf_Id,
                        principalTable: "Shelf_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Author_Book_",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_Book_", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_Author_Book__Author__Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Author_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Author_Book__Book__Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Book_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Category_",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Category_", x => new { x.Book_Id, x.Category_Id });
                    table.ForeignKey(
                        name: "FK_Book_Category__Book__Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Book_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category__Category__Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Tag_",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Tag_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Tag_", x => new { x.Book_Id, x.Tag_Id });
                    table.ForeignKey(
                        name: "FK_Book_Tag__Book__Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Book_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Tag__Tag__Tag_Id",
                        column: x => x.Tag_Id,
                        principalTable: "Tag_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category_",
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
                table: "Reader_",
                columns: new[] { "Id", "BirthDate", "Full_Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иванов Иван Иванович", new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1992, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Квашнин Петр Михайлович", new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2001, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петрухин Александр Андреевич", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shelf_",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" }
                });

            migrationBuilder.InsertData(
                table: "Tag_",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "#war" },
                    { 2, "#love" },
                    { 3, "#KILLA" }
                });

            migrationBuilder.InsertData(
                table: "Book_",
                columns: new[] { "Id", "PhotoPath", "Reader_Id", "Shelf_Id", "TakeDate", "Title" },
                values: new object[] { 1, "infjoke.jpg", 1, 1, new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бесконечная шутка" });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Book__Author_Id",
                table: "Author_Book_",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book__Reader_Id",
                table: "Book_",
                column: "Reader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book__Shelf_Id",
                table: "Book_",
                column: "Shelf_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category__Category_Id",
                table: "Book_Category_",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Tag__Tag_Id",
                table: "Book_Tag_",
                column: "Tag_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author_Book_");

            migrationBuilder.DropTable(
                name: "Book_Category_");

            migrationBuilder.DropTable(
                name: "Book_Tag_");

            migrationBuilder.DropTable(
                name: "Author_");

            migrationBuilder.DropTable(
                name: "Category_");

            migrationBuilder.DropTable(
                name: "Book_");

            migrationBuilder.DropTable(
                name: "Tag_");

            migrationBuilder.DropTable(
                name: "Reader_");

            migrationBuilder.DropTable(
                name: "Shelf_");

            migrationBuilder.CreateTable(
                name: "Authors_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reader_Id = table.Column<int>(type: "int", nullable: false),
                    Shelf_Id = table.Column<int>(type: "int", nullable: false),
                    TakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "Id", "BirthDate", "Full_Name", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иванов Иван Иванович", new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1992, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Квашнин Петр Михайлович", new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2001, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петрухин Александр Андреевич", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.InsertData(
                table: "Books_",
                columns: new[] { "Id", "PhotoPath", "Reader_Id", "Shelf_Id", "TakeDate", "Title" },
                values: new object[] { 1, "infjoke.jpg", 1, 1, new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бесконечная шутка" });

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
    }
}

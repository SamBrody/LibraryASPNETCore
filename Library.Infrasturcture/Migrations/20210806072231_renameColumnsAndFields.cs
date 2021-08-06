using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrasturcture.Migrations
{
    public partial class renameColumnsAndFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book__Reader__ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book__Shelf__ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelf_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Author_Book_",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_Book_", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Author_Book__Author__AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Author_Book__Book__BookId",
                        column: x => x.BookId,
                        principalTable: "Book_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Category_",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Category_", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Book_Category__Book__BookId",
                        column: x => x.BookId,
                        principalTable: "Book_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category__Category__CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Tag_",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Tag_", x => new { x.BookId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Book_Tag__Book__BookId",
                        column: x => x.BookId,
                        principalTable: "Book_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Tag__Tag__TagId",
                        column: x => x.TagId,
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
                columns: new[] { "Id", "BirthDate", "FullName", "RegistrationDate" },
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
                columns: new[] { "Id", "PhotoPath", "ReaderId", "ShelfId", "TakeDate", "Title" },
                values: new object[] { 1, "infjoke.jpg", 1, 1, new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бесконечная шутка" });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Book__AuthorId",
                table: "Author_Book_",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book__ReaderId",
                table: "Book_",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Book__ShelfId",
                table: "Book_",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category__CategoryId",
                table: "Book_Category_",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Tag__TagId",
                table: "Book_Tag_",
                column: "TagId");
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
        }
    }
}

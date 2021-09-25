using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.Bookstore.Migrations
{
    public partial class addedColumnForPdfUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Books_BooksId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_BooksId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Gallery");

            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_BookId",
                table: "Gallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Books_BookId",
                table: "Gallery",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Books_BookId",
                table: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_BookId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Gallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_BooksId",
                table: "Gallery",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Books_BooksId",
                table: "Gallery",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

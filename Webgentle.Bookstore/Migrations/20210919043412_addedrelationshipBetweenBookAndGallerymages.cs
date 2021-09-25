using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.Bookstore.Migrations
{
    public partial class addedrelationshipBetweenBookAndGallerymages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Gallery",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

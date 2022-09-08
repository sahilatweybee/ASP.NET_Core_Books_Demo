using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNET_Core_Books_Demo.Migrations
{
    public partial class UpdatedGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Tbl_Book_Tbl_BooksId",
                table: "Gallery_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_Tbl_BooksId",
                table: "Gallery_Tbl");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Gallery_Tbl");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_Tbl_BookId",
                table: "Gallery_Tbl",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Tbl_Book_Tbl_BookId",
                table: "Gallery_Tbl",
                column: "BookId",
                principalTable: "Book_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Tbl_Book_Tbl_BookId",
                table: "Gallery_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_Tbl_BookId",
                table: "Gallery_Tbl");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Gallery_Tbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_Tbl_BooksId",
                table: "Gallery_Tbl",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Tbl_Book_Tbl_BooksId",
                table: "Gallery_Tbl",
                column: "BooksId",
                principalTable: "Book_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

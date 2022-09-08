using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNET_Core_Books_Demo.Migrations
{
    public partial class AddedFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImgPathUrl",
                table: "Book_Tbl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImgPathUrl",
                table: "Book_Tbl");
        }
    }
}

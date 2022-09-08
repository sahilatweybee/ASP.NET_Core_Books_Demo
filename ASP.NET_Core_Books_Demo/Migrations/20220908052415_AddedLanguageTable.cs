using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNET_Core_Books_Demo.Migrations
{
    public partial class AddedLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Book_Tbl");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Book_Tbl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Language_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language_Tbl", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Tbl_LanguageId",
                table: "Book_Tbl",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Tbl_Language_Tbl_LanguageId",
                table: "Book_Tbl",
                column: "LanguageId",
                principalTable: "Language_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Tbl_Language_Tbl_LanguageId",
                table: "Book_Tbl");

            migrationBuilder.DropTable(
                name: "Language_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Book_Tbl_LanguageId",
                table: "Book_Tbl");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Book_Tbl");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Book_Tbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

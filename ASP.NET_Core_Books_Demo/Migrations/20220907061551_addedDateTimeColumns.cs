using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNET_Core_Books_Demo.Migrations
{
    public partial class addedDateTimeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Book_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Book_Tbl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Book_Tbl");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Book_Tbl");
        }
    }
}

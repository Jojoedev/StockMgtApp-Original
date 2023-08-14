using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMgtApp.Migrations
{
    public partial class addingDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "STOCKMGT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ItemCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "STOCKMGT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ItemCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

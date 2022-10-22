using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMgtApp.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_STOCKMGT",
                table: "STOCKMGT");

            migrationBuilder.RenameTable(
                name: "STOCKMGT",
                newName: "StockItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockItem",
                table: "StockItem",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockItem",
                table: "StockItem");

            migrationBuilder.RenameTable(
                name: "StockItem",
                newName: "STOCKMGT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STOCKMGT",
                table: "STOCKMGT",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosCivil.Api.Migrations
{
    public partial class RemovedStockField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Stock",
                table: "Items",
                type: "numeric",
                nullable: true);
        }
    }
}

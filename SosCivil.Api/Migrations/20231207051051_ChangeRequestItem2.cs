using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosCivil.Api.Migrations
{
    public partial class ChangeRequestItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Occurences_OccurrenceId",
                table: "RequestItems");

            migrationBuilder.DropIndex(
                name: "IX_RequestItems_OccurrenceId",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "OccurrenceId",
                table: "RequestItems");

            migrationBuilder.CreateIndex(
                name: "IX_Occurences_RequestItemId",
                table: "Occurences",
                column: "RequestItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occurences_RequestItems_RequestItemId",
                table: "Occurences",
                column: "RequestItemId",
                principalTable: "RequestItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occurences_RequestItems_RequestItemId",
                table: "Occurences");

            migrationBuilder.DropIndex(
                name: "IX_Occurences_RequestItemId",
                table: "Occurences");

            migrationBuilder.AddColumn<long>(
                name: "OccurrenceId",
                table: "RequestItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_OccurrenceId",
                table: "RequestItems",
                column: "OccurrenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Occurences_OccurrenceId",
                table: "RequestItems",
                column: "OccurrenceId",
                principalTable: "Occurences",
                principalColumn: "Id");
        }
    }
}

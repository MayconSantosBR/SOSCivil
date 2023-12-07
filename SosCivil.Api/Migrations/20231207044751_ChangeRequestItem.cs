using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosCivil.Api.Migrations
{
    public partial class ChangeRequestItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Requests_RequestId",
                table: "RequestItems");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "RequestItems",
                newName: "OccurrenceId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_RequestId",
                table: "RequestItems",
                newName: "IX_RequestItems_OccurrenceId");

            migrationBuilder.AddColumn<long>(
                name: "RequestItemId",
                table: "Occurences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Occurences_OccurrenceId",
                table: "RequestItems",
                column: "OccurrenceId",
                principalTable: "Occurences",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Occurences_OccurrenceId",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "RequestItemId",
                table: "Occurences");

            migrationBuilder.RenameColumn(
                name: "OccurrenceId",
                table: "RequestItems",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_OccurrenceId",
                table: "RequestItems",
                newName: "IX_RequestItems_RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Requests_RequestId",
                table: "RequestItems",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }
    }
}

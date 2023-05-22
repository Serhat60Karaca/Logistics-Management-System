using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsManagement.Migrations
{
    public partial class fkremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personnel_AspNetUsers_AppUserId",
                table: "personnel");

            migrationBuilder.DropIndex(
                name: "IX_personnel_AppUserId",
                table: "personnel");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "personnel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "personnel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_personnel_AppUserId",
                table: "personnel",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_personnel_AspNetUsers_AppUserId",
                table: "personnel",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

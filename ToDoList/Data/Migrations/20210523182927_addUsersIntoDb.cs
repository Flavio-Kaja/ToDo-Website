using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Data.Migrations
{
    public partial class addUsersIntoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entries_AppUserId",
                table: "entries",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_entries_AspNetUsers_AppUserId",
                table: "entries",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entries_AspNetUsers_AppUserId",
                table: "entries");

            migrationBuilder.DropIndex(
                name: "IX_entries_AppUserId",
                table: "entries");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "entries");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}

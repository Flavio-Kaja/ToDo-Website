using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Data.Migrations
{
    public partial class AddUserIdToPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "currentUserId",
                table: "entries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentUserId",
                table: "entries");
        }
    }
}

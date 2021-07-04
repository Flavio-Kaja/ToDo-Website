using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Data.Migrations
{
    public partial class addEntriesIntoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entries");
        }
    }
}

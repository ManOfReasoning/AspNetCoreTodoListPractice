using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListBreeze.Migrations
{
    public partial class WithNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTasks",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTasks",
                table: "AspNetUsers");
        }
    }
}

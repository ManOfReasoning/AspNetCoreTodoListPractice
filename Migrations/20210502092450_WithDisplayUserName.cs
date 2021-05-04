using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListBreeze.Migrations
{
    public partial class WithDisplayUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayUserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayUserName",
                table: "AspNetUsers");
        }
    }
}

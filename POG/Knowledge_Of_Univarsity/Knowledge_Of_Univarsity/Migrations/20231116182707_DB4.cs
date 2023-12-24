using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledge_Of_Univarsity.Migrations
{
    public partial class DB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Colleges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Colleges");
        }
    }
}

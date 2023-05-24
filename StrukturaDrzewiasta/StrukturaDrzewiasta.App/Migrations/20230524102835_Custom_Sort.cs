using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrukturaDrzewiasta.App.Migrations
{
    public partial class Custom_Sort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomSortId",
                table: "Node",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomSortId",
                table: "Node");
        }
    }
}

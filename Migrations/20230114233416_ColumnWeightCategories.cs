using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEF.Migrations
{
    public partial class ColumnWeightCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "CATEGORIES",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "CATEGORIES");
        }
    }
}

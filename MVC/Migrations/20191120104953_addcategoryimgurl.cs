using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashion.Migrations
{
    public partial class addcategoryimgurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Category");
        }
    }
}

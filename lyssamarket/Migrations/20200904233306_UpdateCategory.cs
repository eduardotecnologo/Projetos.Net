using Microsoft.EntityFrameworkCore.Migrations;

namespace lyssamarket.Migrations
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categorys",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categorys",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categorys");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categorys",
                newName: "name");
        }
    }
}

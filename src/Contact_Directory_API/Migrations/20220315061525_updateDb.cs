using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Directory_API.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Persons",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Persons",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Persons",
                newName: "Name");
        }
    }
}

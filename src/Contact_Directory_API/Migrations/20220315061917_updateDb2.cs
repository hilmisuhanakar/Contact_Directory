using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Directory_API.Migrations
{
    public partial class updateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "emaikl2",
                table: "Persons",
                newName: "email2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email2",
                table: "Persons",
                newName: "emaikl2");
        }
    }
}

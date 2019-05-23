using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Persistence.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_FirstName",
                table: "People",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_People_LastName",
                table: "People",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_FirstName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_LastName",
                table: "People");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Persistence.Migrations
{
    public partial class PictureUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "People",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "images/peter_parker.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "images/tony_stark.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "images/thor_odinson.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "images/bruce_banner.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "images/steve_rogers.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "People");
        }
    }
}

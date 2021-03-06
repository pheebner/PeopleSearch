﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Persistence.Migrations
{
    public partial class ImageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "image/peter_parker.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "image/tony_stark.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUrl",
                value: "image/thor_odinson.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUrl",
                value: "image/bruce_banner.png");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUrl",
                value: "image/steve_rogers.png");
        }
    }
}

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GISDevelopment.Migrations
{
    /// <inheritdoc />
    public partial class TagsForUserEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Tags",
                table: "UserPolygons",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Tags",
                table: "UserPoints",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "Tags",
                table: "UserLines",
                type: "hstore",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "UserPolygons");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "UserPoints");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "UserLines");
        }
    }
}

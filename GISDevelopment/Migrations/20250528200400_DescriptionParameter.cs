using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GISDevelopment.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrition",
                table: "UserLines",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "UserLines",
                newName: "Descrition");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLine_DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class iformfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResumeURL",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeURL",
                table: "Users");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLine_DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class isapproved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsApproved",
                table: "Applied_Jobs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Applied_Jobs");
        }
    }
}

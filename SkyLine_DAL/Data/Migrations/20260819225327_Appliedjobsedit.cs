using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLine_DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class Appliedjobsedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applied_Jobs_Users_UserId1",
                table: "Applied_Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Applied_Jobs_UserId1",
                table: "Applied_Jobs");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Applied_Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Applied_Jobs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Applied_Jobs_UserId",
                table: "Applied_Jobs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applied_Jobs_Users_UserId",
                table: "Applied_Jobs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applied_Jobs_Users_UserId",
                table: "Applied_Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Applied_Jobs_UserId",
                table: "Applied_Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Applied_Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Applied_Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applied_Jobs_UserId1",
                table: "Applied_Jobs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applied_Jobs_Users_UserId1",
                table: "Applied_Jobs",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

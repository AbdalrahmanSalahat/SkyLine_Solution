using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLine_DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class Appliedjobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applied_Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applied_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applied_Jobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applied_Jobs_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applied_Jobs_JobId",
                table: "Applied_Jobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Applied_Jobs_UserId1",
                table: "Applied_Jobs",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applied_Jobs");
        }
    }
}

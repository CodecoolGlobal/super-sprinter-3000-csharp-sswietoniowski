using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperSprinter3000.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserStories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AcceptanceCriteria = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    BusinessValue = table.Column<int>(type: "INTEGER", nullable: false),
                    Estimation = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserStories",
                columns: new[] { "Id", "AcceptanceCriteria", "BusinessValue", "Description", "Estimation", "Title" },
                values: new object[,]
                {
                    { 1, "Acceptance Criteria 1", 100, "Description 1", 0.5m, "User Story 1" },
                    { 2, "Acceptance Criteria 2", 200, "Description 2", 1m, "User Story 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStories");
        }
    }
}

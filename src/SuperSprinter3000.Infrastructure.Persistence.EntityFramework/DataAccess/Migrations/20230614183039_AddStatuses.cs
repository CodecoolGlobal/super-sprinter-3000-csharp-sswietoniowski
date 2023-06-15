using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperSprinter3000.Migrations
{
    /// <inheritdoc />
    public partial class AddStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserStories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserStories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "InProgress");

            migrationBuilder.UpdateData(
                table: "UserStories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Todo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserStories");
        }
    }
}

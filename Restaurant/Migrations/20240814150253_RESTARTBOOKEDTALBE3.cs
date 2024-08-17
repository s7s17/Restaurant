using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class RESTARTBOOKEDTALBE3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTable",
                table: "BookedTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTable",
                table: "BookedTable",
                columns: new[] { "TableNum", "BookDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTable",
                table: "BookedTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTable",
                table: "BookedTable",
                columns: new[] { "TableNum", "UserID" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class edituserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTables_AspNetUsers_UserId",
                table: "bookedTables");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bookedTables",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTables_UserId",
                table: "bookedTables",
                newName: "IX_bookedTables_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTables_AspNetUsers_Email",
                table: "bookedTables",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTables_AspNetUsers_Email",
                table: "bookedTables");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "bookedTables",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTables_Email",
                table: "bookedTables",
                newName: "IX_bookedTables_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTables_AspNetUsers_UserId",
                table: "bookedTables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class edituserid2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTables_AspNetUsers_Email",
                table: "bookedTables");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "bookedTables",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTables_Email",
                table: "bookedTables",
                newName: "IX_bookedTables_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTables_AspNetUsers_UserID",
                table: "bookedTables",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTables_AspNetUsers_UserID",
                table: "bookedTables");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "bookedTables",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTables_UserID",
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
    }
}

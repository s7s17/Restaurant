using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class RESTARTBOOKEDTALBE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTables_AspNetUsers_UserID",
                table: "bookedTables");

            migrationBuilder.DropForeignKey(
                name: "FK_bookedTables_Table_TableNum",
                table: "bookedTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookedTables",
                table: "bookedTables");

            migrationBuilder.RenameTable(
                name: "bookedTables",
                newName: "BookedTable");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTables_UserID",
                table: "BookedTable",
                newName: "IX_BookedTable_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTable",
                table: "BookedTable",
                columns: new[] { "TableNum", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTable_AspNetUsers_UserID",
                table: "BookedTable",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTable_Table_TableNum",
                table: "BookedTable",
                column: "TableNum",
                principalTable: "Table",
                principalColumn: "TableNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTable_AspNetUsers_UserID",
                table: "BookedTable");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTable_Table_TableNum",
                table: "BookedTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTable",
                table: "BookedTable");

            migrationBuilder.RenameTable(
                name: "BookedTable",
                newName: "bookedTables");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTable_UserID",
                table: "bookedTables",
                newName: "IX_bookedTables_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookedTables",
                table: "bookedTables",
                columns: new[] { "TableNum", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTables_AspNetUsers_UserID",
                table: "bookedTables",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTables_Table_TableNum",
                table: "bookedTables",
                column: "TableNum",
                principalTable: "Table",
                principalColumn: "TableNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

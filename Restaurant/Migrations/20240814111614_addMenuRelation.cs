using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class addMenuRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menuItems_menuCategories_CategoryId",
                table: "menuItems");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "menuItems",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_menuItems_CategoryId",
                table: "menuItems",
                newName: "IX_menuItems_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_menuItems_menuCategories_CategoryID",
                table: "menuItems",
                column: "CategoryID",
                principalTable: "menuCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menuItems_menuCategories_CategoryID",
                table: "menuItems");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "menuItems",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_menuItems_CategoryID",
                table: "menuItems",
                newName: "IX_menuItems_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_menuItems_menuCategories_CategoryId",
                table: "menuItems",
                column: "CategoryId",
                principalTable: "menuCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

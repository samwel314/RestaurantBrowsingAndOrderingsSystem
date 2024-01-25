using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystemDataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdateMenuModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menu",
                newName: "Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                columns: new[] { "RestaurantId", "Type" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Menu",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu",
                column: "RestaurantId");
        }
    }
}

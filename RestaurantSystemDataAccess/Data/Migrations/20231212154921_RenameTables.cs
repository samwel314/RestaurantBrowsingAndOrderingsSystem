using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystemDataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Menu_MenuId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Restaurants_RestaurantId",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menus",
                newName: "IX_Menus_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_MenuId",
                table: "Meals",
                newName: "IX_Meals_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menu",
                newName: "IX_Menu_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_MenuId",
                table: "Meal",
                newName: "IX_Meal_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Menu_MenuId",
                table: "Meal",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Restaurants_RestaurantId",
                table: "Menu",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

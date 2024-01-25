using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystemDataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMealandUpdateeMenuModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

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

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Offer = table.Column<double>(type: "float", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_MenuId",
                table: "Meal",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                columns: new[] { "RestaurantId", "Type" });
        }
    }
}

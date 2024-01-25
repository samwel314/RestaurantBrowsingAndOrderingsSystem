using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystemDataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Meals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Meals");
        }
    }
}

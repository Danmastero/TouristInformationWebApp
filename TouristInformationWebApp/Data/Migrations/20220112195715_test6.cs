using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristInformationWebApp.Data.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "RestaurantRating",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "HotelRating",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "AttractionRating",
                newName: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RestaurantRating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HotelRating",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RestaurantRating");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelRating");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "RestaurantRating",
                newName: "Stars");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "HotelRating",
                newName: "Stars");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "AttractionRating",
                newName: "Stars");
        }
    }
}

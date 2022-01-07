using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristInformationWebApp.Data.Migrations
{
    public partial class AddedTourIdToReservation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "HotelComments");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "HotelComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttractionId",
                table: "HotelComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "HotelComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

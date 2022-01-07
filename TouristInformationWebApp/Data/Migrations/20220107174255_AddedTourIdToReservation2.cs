using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristInformationWebApp.Data.Migrations
{
    public partial class AddedTourIdToReservation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Reservation_ReservationId",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_Tour_ReservationId",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Tour");

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Tour",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tour_ReservationId",
                table: "Tour",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Reservation_ReservationId",
                table: "Tour",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

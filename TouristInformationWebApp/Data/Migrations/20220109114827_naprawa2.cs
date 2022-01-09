using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristInformationWebApp.Data.Migrations
{
    public partial class naprawa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TourId",
                table: "Reservation",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Tour_TourId",
                table: "Reservation",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Tour_TourId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_TourId",
                table: "Reservation");
        }
    }
}

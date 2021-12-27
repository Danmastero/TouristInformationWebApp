using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristInformationWebApp.Data.Migrations
{
    public partial class migrationnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Tour",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NumOfSeats = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tour_ReservationId",
                table: "Tour",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelComments_HotelId",
                table: "HotelComments",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelComments_Hotel_HotelId",
                table: "HotelComments",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Reservation_ReservationId",
                table: "Tour",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelComments_Hotel_HotelId",
                table: "HotelComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Reservation_ReservationId",
                table: "Tour");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Tour_ReservationId",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_HotelComments_HotelId",
                table: "HotelComments");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Tour");
        }
    }
}

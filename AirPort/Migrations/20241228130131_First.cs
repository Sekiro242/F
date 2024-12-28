using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirPort.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airlines",
                columns: table => new
                {
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airlines", x => x.AirlineID);
                });

            migrationBuilder.CreateTable(
                name: "passenger",
                columns: table => new
                {
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger", x => x.PassengerID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<int>(type: "int", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_airlines_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "airlines",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_bookings_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_passenger_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "passenger",
                        principalColumn: "PassengerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_FlightID",
                table: "bookings",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_PassengerID",
                table: "bookings",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineID",
                table: "Flights",
                column: "AirlineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "passenger");

            migrationBuilder.DropTable(
                name: "airlines");
        }
    }
}

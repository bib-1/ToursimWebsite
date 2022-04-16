using Microsoft.EntityFrameworkCore.Migrations;

namespace TourismWebsite.Migrations
{
    public partial class Tourism : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    AgencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "varchar(50)", nullable: false),
                    AgencyHeadOffice = table.Column<string>(type: "varchar(50)", nullable: false),
                    AgencyContact = table.Column<int>(type: "int", nullable: false),
                    AgencyRatings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.AgencyID);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationName = table.Column<string>(type: "varchar(50)", nullable: false),
                    DestinationLocation = table.Column<string>(type: "varchar(50)", nullable: false),
                    DestinationDescription = table.Column<string>(type: "varchar(200)", nullable: false),
                    DestinationPackage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationID);
                });

            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    GuideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideName = table.Column<string>(type: "varchar(50)", nullable: false),
                    GuideGender = table.Column<string>(type: "varchar(6)", nullable: false),
                    GuideContact = table.Column<int>(type: "int", nullable: false),
                    GuidingExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.GuideID);
                });

            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    TouristID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristName = table.Column<string>(type: "varchar(50)", nullable: false),
                    TouristGender = table.Column<string>(type: "varchar(6)", nullable: false),
                    TouristAge = table.Column<int>(type: "int", nullable: false),
                    TouristContact = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.TouristID);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristID = table.Column<int>(type: "int", nullable: false),
                    GuideID = table.Column<int>(type: "int", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    AgencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Agency_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "Agency",
                        principalColumn: "AgencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Destination_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destination",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Guide_GuideID",
                        column: x => x.GuideID,
                        principalTable: "Guide",
                        principalColumn: "GuideID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Tourist_TouristID",
                        column: x => x.TouristID,
                        principalTable: "Tourist",
                        principalColumn: "TouristID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AgencyID",
                table: "Booking",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DestinationID",
                table: "Booking",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_GuideID",
                table: "Booking",
                column: "GuideID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TouristID",
                table: "Booking",
                column: "TouristID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Guide");

            migrationBuilder.DropTable(
                name: "Tourist");
        }
    }
}

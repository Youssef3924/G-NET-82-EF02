using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G_NET_82_EF02.Migrations
{
    /// <inheritdoc />
    public partial class DataBase_Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtendeeTable",
                columns: table => new
                {
                    AtendeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    street = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendeeTable", x => x.AtendeeID);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganizers",
                columns: table => new
                {
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizers", x => x.OrganizerID);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsuuedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtendeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                    table.CheckConstraint("CK_Badge_Tier_StandardOeVIP", "[Tier] IN ('Standard','VIP')");
                    table.ForeignKey(
                        name: "FK_Badge_AtendeeTable_AtendeeID",
                        column: x => x.AtendeeID,
                        principalTable: "AtendeeTable",
                        principalColumn: "AtendeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Desription = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxAtendees = table.Column<int>(type: "int", nullable: false),
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventOrganizers_OrganizerID",
                        column: x => x.OrganizerID,
                        principalTable: "EventOrganizers",
                        principalColumn: "OrganizerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biography = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    WebSite_Url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Logo_Url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizerProfile_EventOrganizers_OrganizerID",
                        column: x => x.OrganizerID,
                        principalTable: "EventOrganizers",
                        principalColumn: "OrganizerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_AtendeeID",
                table: "Badge",
                column: "AtendeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerID",
                table: "Events",
                column: "OrganizerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizerProfile_OrganizerID",
                table: "OrganizerProfile",
                column: "OrganizerID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "OrganizerProfile");

            migrationBuilder.DropTable(
                name: "AtendeeTable");

            migrationBuilder.DropTable(
                name: "EventOrganizers");
        }
    }
}

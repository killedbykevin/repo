using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestelBuddy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bezoekers",
                columns: table => new
                {
                    BezoekerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAdres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bezoekers", x => x.BezoekerId);
                });

            migrationBuilder.CreateTable(
                name: "Evenementen",
                columns: table => new
                {
                    EvenementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Locatie = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenementen", x => x.EvenementId);
                });

            migrationBuilder.CreateTable(
                name: "MenuKaarten",
                columns: table => new
                {
                    MenuKaartId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuKaarten", x => x.MenuKaartId);
                });

            migrationBuilder.CreateTable(
                name: "Planners",
                columns: table => new
                {
                    PlannerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAdres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planners", x => x.PlannerId);
                });

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    BestellingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tijdstip = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TijdstipKlaar = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotaalBedrag = table.Column<double>(type: "REAL", nullable: false),
                    BezoekerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.BestellingId);
                    table.ForeignKey(
                        name: "FK_Bestellingen_Bezoekers_BezoekerId",
                        column: x => x.BezoekerId,
                        principalTable: "Bezoekers",
                        principalColumn: "BezoekerId");
                });

            migrationBuilder.CreateTable(
                name: "Foodtrucks",
                columns: table => new
                {
                    FoodtruckId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Specialiteit = table.Column<string>(type: "TEXT", nullable: false),
                    MenuKaartId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsBeschikbaar = table.Column<bool>(type: "INTEGER", nullable: false),
                    EvenementId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodtrucks", x => x.FoodtruckId);
                    table.ForeignKey(
                        name: "FK_Foodtrucks_Evenementen_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenementen",
                        principalColumn: "EvenementId");
                    table.ForeignKey(
                        name: "FK_Foodtrucks_MenuKaarten_MenuKaartId",
                        column: x => x.MenuKaartId,
                        principalTable: "MenuKaarten",
                        principalColumn: "MenuKaartId");
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Prijs = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    BestellingId = table.Column<int>(type: "INTEGER", nullable: true),
                    MenuKaartId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Bestellingen_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "BestellingId");
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuKaarten_MenuKaartId",
                        column: x => x.MenuKaartId,
                        principalTable: "MenuKaarten",
                        principalColumn: "MenuKaartId");
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    MedewerkerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: false),
                    FoodtruckId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.MedewerkerId);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Foodtrucks_FoodtruckId",
                        column: x => x.FoodtruckId,
                        principalTable: "Foodtrucks",
                        principalColumn: "FoodtruckId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_BezoekerId",
                table: "Bestellingen",
                column: "BezoekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Foodtrucks_EvenementId",
                table: "Foodtrucks",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Foodtrucks_MenuKaartId",
                table: "Foodtrucks",
                column: "MenuKaartId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_FoodtruckId",
                table: "Medewerkers",
                column: "FoodtruckId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_BestellingId",
                table: "MenuItems",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuKaartId",
                table: "MenuItems",
                column: "MenuKaartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Planners");

            migrationBuilder.DropTable(
                name: "Foodtrucks");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Evenementen");

            migrationBuilder.DropTable(
                name: "MenuKaarten");

            migrationBuilder.DropTable(
                name: "Bezoekers");
        }
    }
}

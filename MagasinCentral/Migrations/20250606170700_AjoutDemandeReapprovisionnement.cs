using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MagasinCentral.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDemandeReapprovisionnement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandesReapprovisionnement",
                columns: table => new
                {
                    DemandeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MagasinId = table.Column<int>(type: "integer", nullable: false),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    QuantiteDemandee = table.Column<int>(type: "integer", nullable: false),
                    DateDemande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statut = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesReapprovisionnement", x => x.DemandeId);
                    table.ForeignKey(
                        name: "FK_DemandesReapprovisionnement_Magasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "Magasins",
                        principalColumn: "MagasinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandesReapprovisionnement_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 4, 17, 7, 0, 100, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 6, 5, 17, 7, 0, 100, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 6, 5, 17, 7, 0, 100, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 6, 6, 17, 7, 0, 100, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.CreateIndex(
                name: "IX_DemandesReapprovisionnement_MagasinId",
                table: "DemandesReapprovisionnement",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandesReapprovisionnement_ProduitId",
                table: "DemandesReapprovisionnement",
                column: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandesReapprovisionnement");

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 4, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 6, 5, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 6, 5, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 6, 6, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6966));
        }
    }
}

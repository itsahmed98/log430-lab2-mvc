using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagasinCentral.Migrations
{
    /// <inheritdoc />
    public partial class AjouterLigneVente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Produits_ProduitId",
                table: "Ventes");

            migrationBuilder.DropColumn(
                name: "PrixUnitaire",
                table: "Ventes");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Ventes");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitId",
                table: "Ventes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "LignesVente",
                columns: table => new
                {
                    LigneVenteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VenteId = table.Column<int>(type: "integer", nullable: false),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesVente", x => x.LigneVenteId);
                    table.ForeignKey(
                        name: "FK_LignesVente_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LignesVente_Ventes_VenteId",
                        column: x => x.VenteId,
                        principalTable: "Ventes",
                        principalColumn: "VenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LignesVente",
                columns: new[] { "LigneVenteId", "PrixUnitaire", "ProduitId", "Quantite", "VenteId" },
                values: new object[,]
                {
                    { 1, 1.50m, 1, 2, 1 },
                    { 2, 3.75m, 2, 1, 1 },
                    { 3, 12.00m, 3, 5, 2 },
                    { 4, 45.00m, 4, 1, 3 },
                    { 5, 1.50m, 1, 3, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                columns: new[] { "Date", "ProduitId" },
                values: new object[] { new DateTime(2025, 6, 5, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(561), null });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                columns: new[] { "Date", "ProduitId" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(568), null });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                columns: new[] { "Date", "ProduitId" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(569), null });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                columns: new[] { "Date", "ProduitId" },
                values: new object[] { new DateTime(2025, 6, 7, 22, 23, 43, 23, DateTimeKind.Utc).AddTicks(570), null });

            migrationBuilder.CreateIndex(
                name: "IX_LignesVente_ProduitId",
                table: "LignesVente",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesVente_VenteId",
                table: "LignesVente",
                column: "VenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Produits_ProduitId",
                table: "Ventes",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Produits_ProduitId",
                table: "Ventes");

            migrationBuilder.DropTable(
                name: "LignesVente");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitId",
                table: "Ventes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixUnitaire",
                table: "Ventes",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Ventes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                columns: new[] { "Date", "PrixUnitaire", "ProduitId", "Quantite" },
                values: new object[] { new DateTime(2025, 6, 5, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1431), 1.50m, 1, 10 });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                columns: new[] { "Date", "PrixUnitaire", "ProduitId", "Quantite" },
                values: new object[] { new DateTime(2025, 6, 6, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1440), 12.00m, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                columns: new[] { "Date", "PrixUnitaire", "ProduitId", "Quantite" },
                values: new object[] { new DateTime(2025, 6, 6, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1442), 3.75m, 2, 7 });

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                columns: new[] { "Date", "PrixUnitaire", "ProduitId", "Quantite" },
                values: new object[] { new DateTime(2025, 6, 7, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1443), 45.00m, 4, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Produits_ProduitId",
                table: "Ventes",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "ProduitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

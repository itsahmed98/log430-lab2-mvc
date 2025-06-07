using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagasinCentral.Migrations
{
    /// <inheritdoc />
    public partial class AjouterQuantiteProduitDifferent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MagasinStocksProduits",
                keyColumns: new[] { "MagasinId", "ProduitId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantite",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MagasinStocksProduits",
                keyColumns: new[] { "MagasinId", "ProduitId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantite",
                value: 150);

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 5, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 6, 6, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 6, 6, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 6, 7, 13, 28, 58, 82, DateTimeKind.Utc).AddTicks(1443));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MagasinStocksProduits",
                keyColumns: new[] { "MagasinId", "ProduitId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantite",
                value: 50);

            migrationBuilder.UpdateData(
                table: "MagasinStocksProduits",
                keyColumns: new[] { "MagasinId", "ProduitId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantite",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 4, 19, 15, 27, 376, DateTimeKind.Utc).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 6, 5, 19, 15, 27, 376, DateTimeKind.Utc).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 6, 5, 19, 15, 27, 376, DateTimeKind.Utc).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Ventes",
                keyColumn: "VenteId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 6, 6, 19, 15, 27, 376, DateTimeKind.Utc).AddTicks(3661));
        }
    }
}

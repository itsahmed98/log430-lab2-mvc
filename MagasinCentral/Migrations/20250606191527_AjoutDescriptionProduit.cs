using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagasinCentral.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDescriptionProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Produits",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "ProduitId",
                keyValue: 1,
                column: "Description",
                value: "Stylo à bille bleu");

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "ProduitId",
                keyValue: 2,
                column: "Description",
                value: "Carnet de notes A5");

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "ProduitId",
                keyValue: 3,
                column: "Description",
                value: "Clé USB 16 Go avec protection");

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "ProduitId",
                keyValue: 4,
                column: "Description",
                value: "Casque audio sans fil avec réduction de bruit");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Produits");

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
        }
    }
}

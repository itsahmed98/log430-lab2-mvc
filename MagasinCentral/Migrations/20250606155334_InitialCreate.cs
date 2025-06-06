using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagasinCentral.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magasins",
                columns: table => new
                {
                    MagasinId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magasins", x => x.MagasinId);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Categorie = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Prix = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitId);
                });

            migrationBuilder.CreateTable(
                name: "MagasinStocksProduits",
                columns: table => new
                {
                    MagasinId = table.Column<int>(type: "integer", nullable: false),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagasinStocksProduits", x => new { x.MagasinId, x.ProduitId });
                    table.ForeignKey(
                        name: "FK_MagasinStocksProduits_Magasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "Magasins",
                        principalColumn: "MagasinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagasinStocksProduits_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StocksCentraux",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksCentraux", x => x.ProduitId);
                    table.ForeignKey(
                        name: "FK_StocksCentraux_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventes",
                columns: table => new
                {
                    VenteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MagasinId = table.Column<int>(type: "integer", nullable: false),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventes", x => x.VenteId);
                    table.ForeignKey(
                        name: "FK_Ventes_Magasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "Magasins",
                        principalColumn: "MagasinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventes_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Magasins",
                columns: new[] { "MagasinId", "Adresse", "Nom" },
                values: new object[,]
                {
                    { 1, "10 Rue Principale", "Magasin Centre-Ville" },
                    { 2, "5 Avenue des Étudiants", "Magasin Université" },
                    { 3, "23 Boulevard Nord", "Magasin Quartier Nord" },
                    { 4, "42 Rue du Commerce", "Magasin Sud-Ouest" }
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "ProduitId", "Categorie", "Nom", "Prix" },
                values: new object[,]
                {
                    { 1, "Papeterie", "Stylo", 1.50m },
                    { 2, "Papeterie", "Carnet", 3.75m },
                    { 3, "Électronique", "Clé USB 16 Go", 12.00m },
                    { 4, "Électronique", "Casque Audio", 45.00m }
                });

            migrationBuilder.InsertData(
                table: "MagasinStocksProduits",
                columns: new[] { "MagasinId", "ProduitId", "Quantite" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 1, 2, 50 },
                    { 1, 3, 50 },
                    { 1, 4, 50 },
                    { 2, 1, 50 },
                    { 2, 2, 50 },
                    { 2, 3, 50 },
                    { 2, 4, 50 },
                    { 3, 1, 50 },
                    { 3, 2, 50 },
                    { 3, 3, 50 },
                    { 3, 4, 50 },
                    { 4, 1, 50 },
                    { 4, 2, 50 },
                    { 4, 3, 50 },
                    { 4, 4, 50 }
                });

            migrationBuilder.InsertData(
                table: "StocksCentraux",
                columns: new[] { "ProduitId", "Quantite" },
                values: new object[,]
                {
                    { 1, 200 },
                    { 2, 200 },
                    { 3, 200 },
                    { 4, 200 }
                });

            migrationBuilder.InsertData(
                table: "Ventes",
                columns: new[] { "VenteId", "Date", "MagasinId", "PrixUnitaire", "ProduitId", "Quantite" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 4, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6953), 1, 1.50m, 1, 10 },
                    { 2, new DateTime(2025, 6, 5, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6963), 2, 12.00m, 3, 5 },
                    { 3, new DateTime(2025, 6, 5, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6964), 1, 3.75m, 2, 7 },
                    { 4, new DateTime(2025, 6, 6, 15, 53, 33, 699, DateTimeKind.Utc).AddTicks(6966), 3, 45.00m, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MagasinStocksProduits_ProduitId",
                table: "MagasinStocksProduits",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_MagasinId",
                table: "Ventes",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_ProduitId",
                table: "Ventes",
                column: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MagasinStocksProduits");

            migrationBuilder.DropTable(
                name: "StocksCentraux");

            migrationBuilder.DropTable(
                name: "Ventes");

            migrationBuilder.DropTable(
                name: "Magasins");

            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}

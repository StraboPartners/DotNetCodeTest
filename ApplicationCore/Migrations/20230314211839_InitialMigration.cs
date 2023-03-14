using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplicationCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceTypes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypes", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasure", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductNumber = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    UnitOfMeasureName = table.Column<string>(type: "text", nullable: false),
                    MinimumOrderQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_UnitsOfMeasure_UnitOfMeasureName",
                        column: x => x.UnitOfMeasureName,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    PriceTypeName = table.Column<string>(type: "character varying(20)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitOfMeasureName = table.Column<string>(type: "text", nullable: false),
                    QuantityFrom = table.Column<int>(type: "integer", nullable: true),
                    QuantityTo = table.Column<int>(type: "integer", nullable: true),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_PriceTypes_PriceTypeName",
                        column: x => x.PriceTypeName,
                        principalTable: "PriceTypes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prices_UnitsOfMeasure_UnitOfMeasureName",
                        column: x => x.UnitOfMeasureName,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_PriceTypeName",
                table: "Prices",
                column: "PriceTypeName");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId_PriceTypeName_FromDate_QuantityFrom",
                table: "Prices",
                columns: new[] { "ProductId", "PriceTypeName", "FromDate", "QuantityFrom" });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_UnitOfMeasureName",
                table: "Prices",
                column: "UnitOfMeasureName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductNumber",
                table: "Products",
                column: "ProductNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitOfMeasureName",
                table: "Products",
                column: "UnitOfMeasureName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "PriceTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");
        }
    }
}

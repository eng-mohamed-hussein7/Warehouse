using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPurchaseInvoiceHeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfAddition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseInvoiceHeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResivedQuantity = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    PurchaseInvoiceHead_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfAddition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPurchaseInvoiceDetails_tblProducts_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblPurchaseInvoiceDetails_tblPurchaseInvoiceHeads_PurchaseInvoiceHead_ID",
                        column: x => x.PurchaseInvoiceHead_ID,
                        principalTable: "tblPurchaseInvoiceHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseInvoiceDetails_Product_ID",
                table: "tblPurchaseInvoiceDetails",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseInvoiceDetails_PurchaseInvoiceHead_ID",
                table: "tblPurchaseInvoiceDetails",
                column: "PurchaseInvoiceHead_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPurchaseInvoiceDetails");

            migrationBuilder.DropTable(
                name: "tblPurchaseInvoiceHeads");
        }
    }
}

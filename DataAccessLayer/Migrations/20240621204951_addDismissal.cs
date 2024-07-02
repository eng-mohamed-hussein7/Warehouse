using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addDismissal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "tblPurchaseInvoiceHeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "tblPurchaseInvoiceDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblDismissalNoticeHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfAddition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDismissalNoticeHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDismissalNoticeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DismissalNoticeHeader_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfAddition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDismissalNoticeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDismissalNoticeDetails_tblDismissalNoticeHeader_DismissalNoticeHeader_ID",
                        column: x => x.DismissalNoticeHeader_ID,
                        principalTable: "tblDismissalNoticeHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblDismissalNoticeDetails_tblProducts_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDismissalNoticeDetails_DismissalNoticeHeader_ID",
                table: "tblDismissalNoticeDetails",
                column: "DismissalNoticeHeader_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDismissalNoticeDetails_Product_ID",
                table: "tblDismissalNoticeDetails",
                column: "Product_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDismissalNoticeDetails");

            migrationBuilder.DropTable(
                name: "tblDismissalNoticeHeader");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "tblPurchaseInvoiceHeads");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "tblPurchaseInvoiceDetails");
        }
    }
}

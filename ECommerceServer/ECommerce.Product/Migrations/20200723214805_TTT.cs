using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Product.Migrations
{
    public partial class TTT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductItemList",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    NrIntern = table.Column<string>(nullable: true),
                    PricePerPQ = table.Column<decimal>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SupplierEmail = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    DeliveryTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemList", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItemList");
        }
    }
}

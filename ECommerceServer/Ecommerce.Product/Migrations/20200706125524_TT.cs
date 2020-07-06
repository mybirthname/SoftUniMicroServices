using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Product.Migrations
{
    public partial class TT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    NrIntern = table.Column<string>(nullable: false),
                    PricePerPQ = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    URL = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SupplierID = table.Column<Guid>(nullable: false),
                    DeliveryTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

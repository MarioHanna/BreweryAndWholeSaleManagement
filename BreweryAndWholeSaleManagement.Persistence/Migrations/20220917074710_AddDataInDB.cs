using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryAndWholeSaleManagement.Persistence.Migrations
{
    public partial class AddDataInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brewerys",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModificationDate", "LastModifiedBy", "Name" },
                values: new object[] { 1, null, null, null, null, "Abbaye de Leffe" });

            migrationBuilder.InsertData(
                table: "Wholesalers",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModificationDate", "LastModifiedBy", "Name" },
                values: new object[] { 1, null, null, null, null, "GeneDrinks" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholContent", "BreweryId", "CreatedBy", "DateCreated", "LastModificationDate", "LastModifiedBy", "Name", "Price" },
                values: new object[] { 1, 6.6, 1, null, null, null, null, "Leffe Blonde", 2.2 });

            migrationBuilder.InsertData(
                table: "WholesalerStocks",
                columns: new[] { "Id", "BeerId", "CreatedBy", "DateCreated", "LastModificationDate", "LastModifiedBy", "Quantity", "WholesalerId" },
                values: new object[] { 1, 1, null, null, null, null, 10, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WholesalerStocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brewerys",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

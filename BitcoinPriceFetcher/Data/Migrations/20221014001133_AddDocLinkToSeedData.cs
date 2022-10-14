using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitcoinPriceFetcher.Data.Migrations
{
    public partial class AddDocLinkToSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1,
                column: "DocumentationLink",
                value: "https://www.bitstamp.net/api/#ticker");

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2,
                column: "DocumentationLink",
                value: "https://docs.bitfinex.com/v1/reference#rest-public-ticker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1,
                column: "DocumentationLink",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2,
                column: "DocumentationLink",
                value: null);
        }
    }
}

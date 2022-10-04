using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstDevelopmentProvinceCity.Data.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "ProvinceId", "ProvinceCode", "ProvinceName" },
                values: new object[] { 2, "ON", "Ontario" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "ProvinceId", "ProvinceCode", "ProvinceName" },
                values: new object[] { 3, "AB", "Alberta" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "Population", "ProvinceId" },
                values: new object[] { 3, "Toronto", 0, 2 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "Population", "ProvinceId" },
                values: new object[] { 4, "Toronto", 0, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "ProvinceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "ProvinceId",
                keyValue: 3);
        }
    }
}

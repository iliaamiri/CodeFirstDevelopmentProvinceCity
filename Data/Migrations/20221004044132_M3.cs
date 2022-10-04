using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstDevelopmentProvinceCity.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Team_ProvinceId",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_City_ProvinceId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "City");

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "City",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode1",
                table: "City",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "ProvinceCode");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 1,
                column: "ProvinceCode",
                value: "BC");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 2,
                column: "ProvinceCode",
                value: "BC");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 3,
                column: "ProvinceCode",
                value: "ON");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 4,
                columns: new[] { "CityName", "ProvinceCode" },
                values: new object[] { "Calgary", "AB" });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceCode1",
                table: "City",
                column: "ProvinceCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Team_ProvinceCode1",
                table: "City",
                column: "ProvinceCode1",
                principalTable: "Team",
                principalColumn: "ProvinceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Team_ProvinceCode1",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_City_ProvinceCode1",
                table: "City");

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "ProvinceCode",
                keyValue: "AB");

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "ProvinceCode",
                keyValue: "BC");

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "ProvinceCode",
                keyValue: "ON");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ProvinceCode1",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Team",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "City",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "ProvinceId");

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "ProvinceId", "ProvinceCode", "ProvinceName" },
                values: new object[] { 1, "BC", "British Columbia" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "ProvinceId", "ProvinceCode", "ProvinceName" },
                values: new object[] { 2, "ON", "Ontario" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "ProvinceId", "ProvinceCode", "ProvinceName" },
                values: new object[] { 3, "AB", "Alberta" });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 1,
                column: "ProvinceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 2,
                column: "ProvinceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 3,
                column: "ProvinceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 4,
                columns: new[] { "CityName", "ProvinceId" },
                values: new object[] { "Toronto", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Team_ProvinceId",
                table: "City",
                column: "ProvinceId",
                principalTable: "Team",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

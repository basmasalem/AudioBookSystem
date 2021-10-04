using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class addCountryIdInCountryMD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CountryMDs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CountryMDs_CountryId",
                table: "CountryMDs",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMDs_Countries_CountryId",
                table: "CountryMDs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryMDs_Countries_CountryId",
                table: "CountryMDs");

            migrationBuilder.DropIndex(
                name: "IX_CountryMDs_CountryId",
                table: "CountryMDs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CountryMDs");
        }
    }
}

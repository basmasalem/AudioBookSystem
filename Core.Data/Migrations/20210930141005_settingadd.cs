using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class settingadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrivacyAr",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivacyEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndConditionsAr",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndConditionsEn",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivacyAr",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "PrivacyEn",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionsAr",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionsEn",
                table: "Setting");
        }
    }
}

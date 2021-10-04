using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class audioupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Audios",
                newName: "BookNameEn");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Audios",
                newName: "BookNameAr");

            migrationBuilder.AddColumn<string>(
                name: "AuthorNameAr",
                table: "Audios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorNameEn",
                table: "Audios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorNameAr",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "AuthorNameEn",
                table: "Audios");

            migrationBuilder.RenameColumn(
                name: "BookNameEn",
                table: "Audios",
                newName: "BookName");

            migrationBuilder.RenameColumn(
                name: "BookNameAr",
                table: "Audios",
                newName: "AuthorName");
        }
    }
}

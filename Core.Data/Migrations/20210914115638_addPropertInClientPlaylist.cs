using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class addPropertInClientPlaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ClientPlaylists",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "DescAr",
                table: "ClientPlaylists",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescEn",
                table: "ClientPlaylists",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "ClientPlaylists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescAr",
                table: "ClientPlaylists");

            migrationBuilder.DropColumn(
                name: "DescEn",
                table: "ClientPlaylists");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "ClientPlaylists");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "ClientPlaylists",
                newName: "Name");
        }
    }
}

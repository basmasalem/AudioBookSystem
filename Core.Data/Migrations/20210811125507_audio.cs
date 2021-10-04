using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class audio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Audios");

            migrationBuilder.AddColumn<bool>(
                name: "ApproveStatus",
                table: "Audios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UploadType",
                table: "Audios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveStatus",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "UploadType",
                table: "Audios");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Audios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

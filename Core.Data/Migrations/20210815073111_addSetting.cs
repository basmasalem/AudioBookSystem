using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class addSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AddressEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InstgramUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WhatsUp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    YouTubeUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.SettingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class addCountInTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FollowersCount",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListenersCount",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowersCount",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ListenersCount",
                table: "Tags");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class clientfollower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientFollowers",
                columns: table => new
                {
                    ClientFollowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscribeId = table.Column<int>(type: "int", nullable: false),
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    FollowingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFollowers", x => x.ClientFollowerId);
                    table.ForeignKey(
                        name: "FK_ClientFollowers_Clients_SubscribeId",
                        column: x => x.SubscribeId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowers_SubscribeId",
                table: "ClientFollowers",
                column: "SubscribeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFollowers");
        }
    }
}

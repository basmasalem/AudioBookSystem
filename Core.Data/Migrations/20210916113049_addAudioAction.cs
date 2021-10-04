using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class addAudioAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioReviews");

            migrationBuilder.DropTable(
                name: "ClientAudioLikes");

            migrationBuilder.CreateTable(
                name: "AudioActions",
                columns: table => new
                {
                    AudioActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Like = table.Column<bool>(type: "bit", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    RateText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Share = table.Column<int>(type: "int", nullable: false),
                    Listen = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioActions", x => x.AudioActionId);
                    table.ForeignKey(
                        name: "FK_AudioActions_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "AudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioActions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioActions_AudioId",
                table: "AudioActions",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioActions_ClientId",
                table: "AudioActions",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioActions");

            migrationBuilder.CreateTable(
                name: "AudioReviews",
                columns: table => new
                {
                    AudioReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioReviews", x => x.AudioReviewId);
                    table.ForeignKey(
                        name: "FK_AudioReviews_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientAudioLikes",
                columns: table => new
                {
                    ClientAudioLikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Like = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAudioLikes", x => x.ClientAudioLikeId);
                    table.ForeignKey(
                        name: "FK_ClientAudioLikes_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "AudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientAudioLikes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioReviews_ClientId",
                table: "AudioReviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAudioLikes_AudioId",
                table: "ClientAudioLikes",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAudioLikes_ClientId",
                table: "ClientAudioLikes",
                column: "ClientId");
        }
    }
}

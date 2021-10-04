using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class InitiativeAudioAndParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InitiativeAudios",
                columns: table => new
                {
                    InitiativeAudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitiativeId = table.Column<int>(type: "int", nullable: false),
                    AudioId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiativeAudios", x => x.InitiativeAudioId);
                    table.ForeignKey(
                        name: "FK_InitiativeAudios_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "AudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InitiativeAudios_Initiatives_InitiativeId",
                        column: x => x.InitiativeId,
                        principalTable: "Initiatives",
                        principalColumn: "InitiativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InitiativeParticipants",
                columns: table => new
                {
                    InitiativeParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitiativeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiativeParticipants", x => x.InitiativeParticipantId);
                    table.ForeignKey(
                        name: "FK_InitiativeParticipants_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InitiativeParticipants_Initiatives_InitiativeId",
                        column: x => x.InitiativeId,
                        principalTable: "Initiatives",
                        principalColumn: "InitiativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeAudios_AudioId",
                table: "InitiativeAudios",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeAudios_InitiativeId",
                table: "InitiativeAudios",
                column: "InitiativeId");

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeParticipants_ClientId",
                table: "InitiativeParticipants",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InitiativeParticipants_InitiativeId",
                table: "InitiativeParticipants",
                column: "InitiativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitiativeAudios");

            migrationBuilder.DropTable(
                name: "InitiativeParticipants");
        }
    }
}

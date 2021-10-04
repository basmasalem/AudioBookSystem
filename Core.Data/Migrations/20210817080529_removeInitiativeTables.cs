using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class removeInitiativeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitiativeAudios");

            migrationBuilder.DropTable(
                name: "InitiativeParticipants");

            migrationBuilder.DropTable(
                name: "Initiatives");

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.PodcastId);
                });

            migrationBuilder.CreateTable(
                name: "PodcastAudio",
                columns: table => new
                {
                    PodcastAudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    AudioId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastAudio", x => x.PodcastAudioId);
                    table.ForeignKey(
                        name: "FK_PodcastAudio_Audios_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Audios",
                        principalColumn: "AudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastAudio_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "PodcastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastParticipant",
                columns: table => new
                {
                    PodcastParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastParticipant", x => x.PodcastParticipantId);
                    table.ForeignKey(
                        name: "FK_PodcastParticipant_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastParticipant_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "PodcastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PodcastAudio_AudioId",
                table: "PodcastAudio",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastAudio_PodcastId",
                table: "PodcastAudio",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastParticipant_ClientId",
                table: "PodcastParticipant",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastParticipant_PodcastId",
                table: "PodcastParticipant",
                column: "PodcastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastAudio");

            migrationBuilder.DropTable(
                name: "PodcastParticipant");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.CreateTable(
                name: "Initiatives",
                columns: table => new
                {
                    InitiativeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Initiatives", x => x.InitiativeId);
                });

            migrationBuilder.CreateTable(
                name: "InitiativeAudios",
                columns: table => new
                {
                    InitiativeAudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitiativeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitiativeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
    }
}

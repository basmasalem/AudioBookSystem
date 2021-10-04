using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class AudioComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "AudioId",
                table: "AudioComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AudioComments_AudioId",
                table: "AudioComments",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AudioComments_Audios_AudioId",
                table: "AudioComments",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "AudioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioComments_Audios_AudioId",
                table: "AudioComments");

            migrationBuilder.DropIndex(
                name: "IX_AudioComments_AudioId",
                table: "AudioComments");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "AudioComments");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

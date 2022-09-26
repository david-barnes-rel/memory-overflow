using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryOverflow.Data.Migrations
{
    public partial class AddTelemetryItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerTelemetry",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTelemetry", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "CommentTelemetry",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTelemetry", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "PostTelemetry",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleLength = table.Column<int>(type: "int", nullable: false),
                    QuestionLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTelemetry", x => x.PostId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerTelemetry");

            migrationBuilder.DropTable(
                name: "CommentTelemetry");

            migrationBuilder.DropTable(
                name: "PostTelemetry");
        }
    }
}

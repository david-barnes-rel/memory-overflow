using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryOverflow.Data.Migrations
{
    public partial class MoreTelemFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerLength",
                table: "CommentTelemetry",
                newName: "CommentLength");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentLength",
                table: "CommentTelemetry",
                newName: "AnswerLength");
        }
    }
}

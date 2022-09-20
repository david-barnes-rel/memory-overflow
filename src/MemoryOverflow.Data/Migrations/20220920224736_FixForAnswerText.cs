using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryOverflow.Data.Migrations
{
    public partial class FixForAnswerText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Answer",
                newName: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Answer",
                newName: "Title");
        }
    }
}

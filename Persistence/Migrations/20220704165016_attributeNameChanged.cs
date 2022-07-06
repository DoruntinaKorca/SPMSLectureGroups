using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class attributeNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExamSeasonStatus",
                table: "LGRS",
                newName: "LectureGroupSeasonStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LectureGroupSeasonStatus",
                table: "LGRS",
                newName: "ExamSeasonStatus");
        }
    }
}

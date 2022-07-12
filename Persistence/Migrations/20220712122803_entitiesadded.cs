using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class entitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSlot",
                table: "LectureGroups");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Lectures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "LectureGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_DayId",
                table: "Lectures",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureGroups_TimeSlotId",
                table: "LectureGroups",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "Lecturegroupss_timest",
                table: "LectureGroups",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "TimeSlotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Lectures_Days",
                table: "Lectures",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Lecturegroupss_timest",
                table: "LectureGroups");

            migrationBuilder.DropForeignKey(
                name: "Lectures_Days",
                table: "Lectures");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_DayId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_LectureGroups_TimeSlotId",
                table: "LectureGroups");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "LectureGroups");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlot",
                table: "LectureGroups",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

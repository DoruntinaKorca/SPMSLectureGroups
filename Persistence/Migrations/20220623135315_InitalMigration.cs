using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicStaff",
                columns: table => new
                {
                    AcademicStaffId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicStaff", x => x.AcademicStaffId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "LectureHalls",
                columns: table => new
                {
                    LectureHallId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HallName = table.Column<string>(type: "TEXT", nullable: true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureHalls", x => x.LectureHallId);
                });

            migrationBuilder.CreateTable(
                name: "LGRS",
                columns: table => new
                {
                    LGRSId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExamSeasonStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Faculty = table.Column<int>(type: "INTEGER", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGRS", x => x.LGRSId);
                });

            migrationBuilder.CreateTable(
                name: "Course_AcademicStaff",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AcademicStaffId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_AcademicStaff", x => new { x.CourseId, x.AcademicStaffId });
                    table.ForeignKey(
                        name: "academicStaffCourse",
                        column: x => x.AcademicStaffId,
                        principalTable: "AcademicStaff",
                        principalColumn: "AcademicStaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "courseAcademicStaff",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureGroups",
                columns: table => new
                {
                    LectureGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(type: "TEXT", nullable: true),
                    TimeSlot = table.Column<string>(type: "TEXT", nullable: true),
                    LGRSId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureGroups", x => x.LectureGroupId);
                    table.ForeignKey(
                        name: "LG_LGRS",
                        column: x => x.LGRSId,
                        principalTable: "LGRS",
                        principalColumn: "LGRSId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LectureType = table.Column<int>(type: "INTEGER", nullable: false),
                    LectureHallId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AcademicStaffId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LectureGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LectureId);
                    table.ForeignKey(
                        name: "courseAcademicSTAFF_FK",
                        columns: x => new { x.CourseId, x.AcademicStaffId },
                        principalTable: "Course_AcademicStaff",
                        principalColumns: new[] { "CourseId", "AcademicStaffId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Lectures_Groups",
                        column: x => x.LectureGroupId,
                        principalTable: "LectureGroups",
                        principalColumn: "LectureGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Lectures_Halls",
                        column: x => x.LectureHallId,
                        principalTable: "LectureHalls",
                        principalColumn: "LectureHallId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_AcademicStaff_AcademicStaffId",
                table: "Course_AcademicStaff",
                column: "AcademicStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureGroups_LGRSId",
                table: "LectureGroups",
                column: "LGRSId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId_AcademicStaffId",
                table: "Lectures",
                columns: new[] { "CourseId", "AcademicStaffId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LectureGroupId",
                table: "Lectures",
                column: "LectureGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LectureHallId",
                table: "Lectures",
                column: "LectureHallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Course_AcademicStaff");

            migrationBuilder.DropTable(
                name: "LectureGroups");

            migrationBuilder.DropTable(
                name: "LectureHalls");

            migrationBuilder.DropTable(
                name: "AcademicStaff");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "LGRS");
        }
    }
}

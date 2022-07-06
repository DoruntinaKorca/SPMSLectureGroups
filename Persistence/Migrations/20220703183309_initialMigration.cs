using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicStaff",
                columns: table => new
                {
                    AcademicStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicStaff", x => x.AcademicStaffId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "LGRS",
                columns: table => new
                {
                    LGRSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamSeasonStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGRS", x => x.LGRSId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Course_AcademicStaff",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AcademicStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureGroups",
                columns: table => new
                {
                    LectureGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGRSId = table.Column<int>(type: "int", nullable: false)
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
                name: "LectureHalls",
                columns: table => new
                {
                    LectureHallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureHalls", x => x.LectureHallId);
                    table.ForeignKey(
                        name: "locationhall",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LectureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LectureHallId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AcademicStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureGroupId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_LectureHalls_LocationId",
                table: "LectureHalls",
                column: "LocationId");

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
                name: "Courses");

            migrationBuilder.DropTable(
                name: "LGRS");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}

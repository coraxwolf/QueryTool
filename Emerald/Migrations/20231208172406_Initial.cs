using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emerald.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseRecords",
                columns: table => new
                {
                    SisId = table.Column<string>(type: "TEXT", nullable: false),
                    Term = table.Column<string>(type: "TEXT", nullable: false),
                    ClassNo = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Catalog = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false),
                    Campus = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Enrolled = table.Column<int>(type: "INTEGER", nullable: false),
                    Cap = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CanvasName = table.Column<string>(type: "TEXT", nullable: true),
                    CanvasCode = table.Column<int>(type: "INTEGER", nullable: true),
                    CanvasState = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRecords", x => x.SisId);
                });

            migrationBuilder.CreateTable(
                name: "FacultyAssignmentRecords",
                columns: table => new
                {
                    SisId = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyNo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyAssignmentRecords", x => new { x.SisId, x.FacultyNo });
                });

            migrationBuilder.CreateTable(
                name: "FacultyRecords",
                columns: table => new
                {
                    FacultyNo = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanvasName = table.Column<string>(type: "TEXT", nullable: true),
                    CanvasCode = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyRecords", x => x.FacultyNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseRecords");

            migrationBuilder.DropTable(
                name: "FacultyAssignmentRecords");

            migrationBuilder.DropTable(
                name: "FacultyRecords");
        }
    }
}

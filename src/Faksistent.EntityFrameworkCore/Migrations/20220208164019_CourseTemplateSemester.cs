using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class CourseTemplateSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseTemplates");

            migrationBuilder.RenameColumn(
                name: "UserSemesterId",
                table: "CourseTemplates",
                newName: "SemesterCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterCourseId",
                table: "CourseTemplates",
                newName: "UserSemesterId");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "CourseTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class SemesterCourseTemplate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseTemplateId",
                table: "SemesterCourses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCourses_CourseTemplateId",
                table: "SemesterCourses",
                column: "CourseTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCourses_CourseTemplates_CourseTemplateId",
                table: "SemesterCourses",
                column: "CourseTemplateId",
                principalTable: "CourseTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCourses_CourseTemplates_CourseTemplateId",
                table: "SemesterCourses");

            migrationBuilder.DropIndex(
                name: "IX_SemesterCourses_CourseTemplateId",
                table: "SemesterCourses");

            migrationBuilder.DropColumn(
                name: "CourseTemplateId",
                table: "SemesterCourses");
        }
    }
}

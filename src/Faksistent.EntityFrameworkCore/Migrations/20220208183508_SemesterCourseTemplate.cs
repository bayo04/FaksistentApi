using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class SemesterCourseTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SemesterCourseId",
                table: "CourseTemplates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "CourseTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CourseTemplates_CourseId",
                table: "CourseTemplates",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTemplates_SemesterCourseId",
                table: "CourseTemplates",
                column: "SemesterCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTemplates_Courses_CourseId",
                table: "CourseTemplates",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTemplates_SemesterCourses_SemesterCourseId",
                table: "CourseTemplates",
                column: "SemesterCourseId",
                principalTable: "SemesterCourses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTemplates_Courses_CourseId",
                table: "CourseTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTemplates_SemesterCourses_SemesterCourseId",
                table: "CourseTemplates");

            migrationBuilder.DropIndex(
                name: "IX_CourseTemplates_CourseId",
                table: "CourseTemplates");

            migrationBuilder.DropIndex(
                name: "IX_CourseTemplates_SemesterCourseId",
                table: "CourseTemplates");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseTemplates");

            migrationBuilder.AlterColumn<Guid>(
                name: "SemesterCourseId",
                table: "CourseTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}

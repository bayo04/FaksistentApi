using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class CourseRestrictionTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseTemplateId",
                table: "CourseRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CourseRestrictions_CourseTemplateId",
                table: "CourseRestrictions",
                column: "CourseTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRestrictions_CourseTemplates_CourseTemplateId",
                table: "CourseRestrictions",
                column: "CourseTemplateId",
                principalTable: "CourseTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRestrictions_CourseTemplates_CourseTemplateId",
                table: "CourseRestrictions");

            migrationBuilder.DropIndex(
                name: "IX_CourseRestrictions_CourseTemplateId",
                table: "CourseRestrictions");

            migrationBuilder.DropColumn(
                name: "CourseTemplateId",
                table: "CourseRestrictions");
        }
    }
}

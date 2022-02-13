using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class UserSemesterDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSemesters_AbpUsers_UserId",
                table: "UserSemesters");

            migrationBuilder.DropIndex(
                name: "IX_UserSemesters_UserId",
                table: "UserSemesters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSemesters");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "UserSemesters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "UserSemesters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserSemesters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "UserSemesters");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "UserSemesters");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserSemesters");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserSemesters",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSemesters_UserId",
                table: "UserSemesters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSemesters_AbpUsers_UserId",
                table: "UserSemesters",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}

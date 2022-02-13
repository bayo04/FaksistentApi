using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class UserSemesterNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSemesters_AbpUsers_UserId",
                table: "UserSemesters");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserSemesters",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSemesters_AbpUsers_UserId",
                table: "UserSemesters",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSemesters_AbpUsers_UserId",
                table: "UserSemesters");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserSemesters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSemesters_AbpUsers_UserId",
                table: "UserSemesters",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

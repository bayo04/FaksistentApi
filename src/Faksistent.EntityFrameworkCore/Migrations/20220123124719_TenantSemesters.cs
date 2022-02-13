using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class TenantSemesters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfSemesters",
                table: "AbpTenants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfSemesters",
                table: "AbpTenants");
        }
    }
}

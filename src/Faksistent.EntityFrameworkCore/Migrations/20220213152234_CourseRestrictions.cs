using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class CourseRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseRestrictions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointsForPass = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsForSignature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseRestrictionTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseRestrictionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRestrictionTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRestrictionTests_CourseRestrictions_CourseRestrictionId",
                        column: x => x.CourseRestrictionId,
                        principalTable: "CourseRestrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRestrictionTests_CourseTests_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "CourseTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseRestrictionTests_CourseRestrictionId",
                table: "CourseRestrictionTests",
                column: "CourseRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRestrictionTests_CourseTestId",
                table: "CourseRestrictionTests",
                column: "CourseTestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseRestrictionTests");

            migrationBuilder.DropTable(
                name: "CourseRestrictions");
        }
    }
}

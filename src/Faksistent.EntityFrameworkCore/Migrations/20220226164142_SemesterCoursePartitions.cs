using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faksistent.Migrations
{
    public partial class SemesterCoursePartitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemesterCoursePartitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRecorded = table.Column<bool>(type: "bit", nullable: false),
                    WasSignatureRecorded = table.Column<bool>(type: "bit", nullable: false),
                    WasPresent = table.Column<bool>(type: "bit", nullable: false),
                    SemesterCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoursePartitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_SemesterCoursePartitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterCoursePartitions_CoursePartition_CoursePartitionId",
                        column: x => x.CoursePartitionId,
                        principalTable: "CoursePartition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterCoursePartitions_SemesterCourses_SemesterCourseId",
                        column: x => x.SemesterCourseId,
                        principalTable: "SemesterCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCoursePartitions_CoursePartitionId",
                table: "SemesterCoursePartitions",
                column: "CoursePartitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCoursePartitions_SemesterCourseId",
                table: "SemesterCoursePartitions",
                column: "SemesterCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemesterCoursePartitions");
        }
    }
}

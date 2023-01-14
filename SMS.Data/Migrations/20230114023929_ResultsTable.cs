using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Data.Migrations
{
    public partial class ResultsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    AdmissionId = table.Column<int>(nullable: false),
                    ClassInfoId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultModels_AdmissionModels_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "AdmissionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultModels_ClassInfoModels_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultModels_SectionModels_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultModels_AdmissionId",
                table: "ResultModels",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultModels_ClassInfoId",
                table: "ResultModels",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultModels_SectionId",
                table: "ResultModels",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultModels");
        }
    }
}

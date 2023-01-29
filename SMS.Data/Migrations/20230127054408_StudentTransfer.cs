using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Data.Migrations
{
    public partial class StudentTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentTransfers",
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
                    TransferInstitute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTransfers_AdmissionModels_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "AdmissionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTransfers_ClassInfoModels_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTransfers_SectionModels_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransfers_AdmissionId",
                table: "StudentTransfers",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransfers_ClassInfoId",
                table: "StudentTransfers",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransfers_SectionId",
                table: "StudentTransfers",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTransfers");
        }
    }
}

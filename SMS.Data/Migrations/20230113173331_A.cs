using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Data.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassInfoModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInfoModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    SectionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Joining = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<string>(nullable: false),
                    StudentPicture = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: false),
                    StudentDOB = table.Column<DateTime>(nullable: false),
                    FatherName = table.Column<string>(nullable: false),
                    FatherOccupation = table.Column<string>(nullable: false),
                    FatherPhoneNumber = table.Column<string>(nullable: false),
                    MotherName = table.Column<string>(nullable: false),
                    MotherOccupation = table.Column<string>(nullable: false),
                    MotherPhoneNumber = table.Column<string>(nullable: false),
                    StudentGender = table.Column<int>(nullable: false),
                    studentAddress = table.Column<string>(nullable: false),
                    StudentPhone = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    NameOfLastStudying = table.Column<string>(nullable: true),
                    ClassInfoId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionModels_ClassInfoModels_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdmissionModels_SectionModels_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionModels_ClassInfoId",
                table: "AdmissionModels",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionModels_SectionId",
                table: "AdmissionModels",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionModels");

            migrationBuilder.DropTable(
                name: "ClassInfoModels");

            migrationBuilder.DropTable(
                name: "SectionModels");
        }
    }
}

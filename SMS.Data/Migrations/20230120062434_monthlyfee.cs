﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Data.Migrations
{
    public partial class monthlyfee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyFeeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    AdmissionId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    ClassInfoId = table.Column<int>(nullable: true),
                    sectionId = table.Column<int>(nullable: false),
                    FeeDate = table.Column<DateTime>(nullable: false),
                    AmountInTaka = table.Column<double>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Payment = table.Column<int>(nullable: false),
                    PaymentDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyFeeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyFeeModels_AdmissionModels_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "AdmissionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyFeeModels_ClassInfoModels_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyFeeModels_SectionModels_sectionId",
                        column: x => x.sectionId,
                        principalTable: "SectionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyFeeModels_AdmissionId",
                table: "MonthlyFeeModels",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyFeeModels_ClassInfoId",
                table: "MonthlyFeeModels",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyFeeModels_sectionId",
                table: "MonthlyFeeModels",
                column: "sectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyFeeModels");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class new_commit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "UNIVERSITY",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIVERSITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 15, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_EMPLOYEE_NIK",
                        column: x => x.NIK,
                        principalTable: "EMPLOYEE",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(nullable: false),
                    GPA = table.Column<string>(nullable: false),
                    UniversityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDUCATION_UNIVERSITY_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "UNIVERSITY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROFILING",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 15, nullable: false),
                    EducationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFILING", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_PROFILING_EDUCATION_EducationId",
                        column: x => x.EducationId,
                        principalTable: "EDUCATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROFILING_ACCOUNT_NIK",
                        column: x => x.NIK,
                        principalTable: "ACCOUNT",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATION_UniversityId",
                table: "EDUCATION",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_PROFILING_EducationId",
                table: "PROFILING",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROFILING");

            migrationBuilder.DropTable(
                name: "EDUCATION");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "UNIVERSITY");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");
        }
    }
}

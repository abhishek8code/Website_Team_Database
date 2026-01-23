using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GECPATAN_FACULTY_PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDepartmentsModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowIntake = table.Column<bool>(type: "bit", nullable: false),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentIntakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    IntakeCount = table.Column<int>(type: "int", nullable: true),
                    IntakeYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentIntakes_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    MissionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMissions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPEOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    PEOText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPEOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentPEOs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentPSOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    PSOText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPSOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentPSOs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentVisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    VisionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentVisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentVisions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    LabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentsId = table.Column<int>(type: "int", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.LabId);
                    table.ForeignKey(
                        name: "FK_Labs_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentIntakes_DepartmentId",
                table: "DepartmentIntakes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMissions_DepartmentId",
                table: "DepartmentMissions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPEOs_DepartmentId",
                table: "DepartmentPEOs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPSOs_DepartmentId",
                table: "DepartmentPSOs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentVisions_DepartmentId",
                table: "DepartmentVisions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Labs_DepartmentsId",
                table: "Labs",
                column: "DepartmentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentIntakes");

            migrationBuilder.DropTable(
                name: "DepartmentMissions");

            migrationBuilder.DropTable(
                name: "DepartmentPEOs");

            migrationBuilder.DropTable(
                name: "DepartmentPSOs");

            migrationBuilder.DropTable(
                name: "DepartmentVisions");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

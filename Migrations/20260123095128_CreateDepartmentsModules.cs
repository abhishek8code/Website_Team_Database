using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GECPATAN_FACULTY_PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDepartmentsModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "DepartmentIntakes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DepartmentIntakes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "DepartmentIntakes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DepartmentIntakes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "DepartmentIntakes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "DepartmentIntakes",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "DepartmentIntakes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DepartmentIntakes");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "DepartmentIntakes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DepartmentIntakes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "DepartmentIntakes");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "DepartmentIntakes");
        }
    }
}

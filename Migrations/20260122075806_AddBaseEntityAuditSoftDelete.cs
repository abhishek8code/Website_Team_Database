using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GECPATAN_FACULTY_PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityAuditSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TrainingAndWorkshops",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "TrainingAndWorkshops",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingAndWorkshops",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TrainingAndWorkshops",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "TrainingAndWorkshops",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "Publications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Publications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Publications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "Publications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProfessionalExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "ProfessionalExperiences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProfessionalExperiences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProfessionalExperiences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "ProfessionalExperiences",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PersonalDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "PersonalDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PersonalDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonalDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "PersonalDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EducationalQualifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "EducationalQualifications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EducationalQualifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "EducationalQualifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "EducationalQualifications",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TrainingAndWorkshops");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "TrainingAndWorkshops");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingAndWorkshops");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TrainingAndWorkshops");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "TrainingAndWorkshops");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EducationalQualifications");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "EducationalQualifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EducationalQualifications");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EducationalQualifications");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "EducationalQualifications");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GECPATAN_FACULTY_PORTAL.Migrations
{
    /// <inheritdoc />
    public partial class CampusCommitteeCrudFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeVisionMissionObjectives");

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "TrainingAndWorkshops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "ProfessionalExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "PersonalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "EducationalQualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "CommitteeMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CommitteeMembers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "CommitteeMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CommitteeMembers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CommitteeMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "CommitteeMembers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "CampusCommittees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CampusCommittees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "CampusCommittees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CampusCommittees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CampusCommittees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "CampusCommittees",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "AdditionalMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdditionalMembers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "AdditionalMembers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdditionalMembers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AdditionalMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "AdditionalMembers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "AdditionalMemberDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AdditionalMemberDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedDateInt",
                table: "AdditionalMemberDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdditionalMemberDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AdditionalMemberDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedDateInt",
                table: "AdditionalMemberDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommitteeMissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    MissionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampusCommitteeId = table.Column<int>(type: "int", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeMissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeMissions_CampusCommittees_CampusCommitteeId",
                        column: x => x.CampusCommitteeId,
                        principalTable: "CampusCommittees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommitteeObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    ObjectiveText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampusCommitteeId = table.Column<int>(type: "int", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeObjectives_CampusCommittees_CampusCommitteeId",
                        column: x => x.CampusCommitteeId,
                        principalTable: "CampusCommittees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommitteeSubObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    SubObjectiveText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampusCommitteeId = table.Column<int>(type: "int", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeSubObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeSubObjectives_CampusCommittees_CampusCommitteeId",
                        column: x => x.CampusCommitteeId,
                        principalTable: "CampusCommittees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommitteeVisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    VisionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampusCommitteeId = table.Column<int>(type: "int", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateInt = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateInt = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeVisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeVisions_CampusCommittees_CampusCommitteeId",
                        column: x => x.CampusCommitteeId,
                        principalTable: "CampusCommittees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMissions_CampusCommitteeId",
                table: "CommitteeMissions",
                column: "CampusCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeObjectives_CampusCommitteeId",
                table: "CommitteeObjectives",
                column: "CampusCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeSubObjectives_CampusCommitteeId",
                table: "CommitteeSubObjectives",
                column: "CampusCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeVisions_CampusCommitteeId",
                table: "CommitteeVisions",
                column: "CampusCommitteeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeMissions");

            migrationBuilder.DropTable(
                name: "CommitteeObjectives");

            migrationBuilder.DropTable(
                name: "CommitteeSubObjectives");

            migrationBuilder.DropTable(
                name: "CommitteeVisions");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "TrainingAndWorkshops");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "EducationalQualifications");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "CampusCommittees");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CampusCommittees");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "CampusCommittees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CampusCommittees");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CampusCommittees");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "CampusCommittees");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "AdditionalMembers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdditionalMembers");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "AdditionalMembers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdditionalMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AdditionalMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "AdditionalMembers");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "AdditionalMemberDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AdditionalMemberDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateInt",
                table: "AdditionalMemberDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdditionalMemberDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AdditionalMemberDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateInt",
                table: "AdditionalMemberDetails");

            migrationBuilder.CreateTable(
                name: "CommitteeVisionMissionObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeVisionMissionObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeVisionMissionObjectives_CampusCommittees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "CampusCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeVisionMissionObjectives_CommitteeId",
                table: "CommitteeVisionMissionObjectives",
                column: "CommitteeId");
        }
    }
}

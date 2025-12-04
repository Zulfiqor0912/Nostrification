using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nostrification.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUz = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NameUz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XtbName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudySteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    ChatId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ClaimerTypeId = table.Column<int>(type: "int", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityCountry = table.Column<int>(type: "int", nullable: true),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyStepId = table.Column<int>(type: "int", nullable: true),
                    StudyTypeId = table.Column<int>(type: "int", nullable: true),
                    DiplomSeria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiplomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiplomGetDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyStartYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyEndYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppostilFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    AnswerFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromOperator = table.Column<bool>(type: "bit", nullable: true),
                    OperatorOrg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    refer_registr_numb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_institution_gos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    graduation_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_educated_gos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    series_doc_diploma_gos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_number_diploma_gos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    head_organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_head_education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registry_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rejection_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PINF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_ClaimStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ClaimStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Claims_ClaimerTypes_ClaimerTypeId",
                        column: x => x.ClaimerTypeId,
                        principalTable: "ClaimerTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Claims_Countries_UniversityCountry",
                        column: x => x.UniversityCountry,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Claims_Regions_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Claims_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Claims_StudySteps_StudyStepId",
                        column: x => x.StudyStepId,
                        principalTable: "StudySteps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Claims_StudyTypes_StudyTypeId",
                        column: x => x.StudyTypeId,
                        principalTable: "StudyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimerTypeId",
                table: "Claims",
                column: "ClaimerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_DistrictId",
                table: "Claims",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_RegionId",
                table: "Claims",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_StatusId",
                table: "Claims",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_StudyStepId",
                table: "Claims",
                column: "StudyStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_StudyTypeId",
                table: "Claims",
                column: "StudyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UniversityCountry",
                table: "Claims",
                column: "UniversityCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegionId",
                table: "Users",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ClaimStatus");

            migrationBuilder.DropTable(
                name: "ClaimerTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "StudySteps");

            migrationBuilder.DropTable(
                name: "StudyTypes");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

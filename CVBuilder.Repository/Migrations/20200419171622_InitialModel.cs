using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVBuilder.Repository.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    CurriculumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudiesIsVisible = table.Column<bool>(nullable: false),
                    WorkExperiencesIsVisible = table.Column<bool>(nullable: false),
                    CertificatesIsVisible = table.Column<bool>(nullable: false),
                    LanguagesIsVisible = table.Column<bool>(nullable: false),
                    SkillsIsVisible = table.Column<bool>(nullable: false),
                    InterestsIsVisible = table.Column<bool>(nullable: false),
                    PersonalReferencesIsVisible = table.Column<bool>(nullable: false),
                    CustomSectionsIsVisible = table.Column<bool>(nullable: false),
                    Id_User = table.Column<int>(nullable: false),
                    Id_Template = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.CurriculumId);
                    table.ForeignKey(
                        name: "FK_Curriculum_Templates_Id_Template",
                        column: x => x.Id_Template,
                        principalTable: "Templates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculum_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Institute = table.Column<string>(maxLength: 100, nullable: false),
                    OnlineMode = table.Column<bool>(nullable: false),
                    InProgress = table.Column<bool>(nullable: false),
                    Year = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_Certificates_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomSections",
                columns: table => new
                {
                    CustomSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomSections", x => x.CustomSectionId);
                    table.ForeignKey(
                        name: "FK_CustomSections_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Level = table.Column<string>(maxLength: 50, nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Languages_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    PersonalDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Profession = table.Column<string>(maxLength: 100, nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    PhotoMimeType = table.Column<string>(maxLength: 25, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<int>(nullable: true),
                    LinePhone = table.Column<int>(nullable: true),
                    AreaCodeLP = table.Column<short>(nullable: true),
                    MobilePhone = table.Column<int>(nullable: true),
                    AreaCodeMP = table.Column<short>(nullable: true),
                    Summary = table.Column<string>(maxLength: 300, nullable: false),
                    SummaryCustomTitle = table.Column<string>(maxLength: 50, nullable: true),
                    SummaryIsVisible = table.Column<bool>(nullable: false),
                    WebPageUrl = table.Column<string>(maxLength: 300, nullable: true),
                    LinkedInUrl = table.Column<string>(maxLength: 300, nullable: true),
                    GithubUrl = table.Column<string>(maxLength: 300, nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 300, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 300, nullable: true),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.PersonalDetailId);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalReferences",
                columns: table => new
                {
                    PersonalReferenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 200, nullable: false),
                    AreaCode = table.Column<short>(nullable: true),
                    Telephone = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalReferences", x => x.PersonalReferenceId);
                    table.ForeignKey(
                        name: "FK_PersonalReferences_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Level = table.Column<string>(maxLength: 50, nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    StudyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Institute = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    StartMonth = table.Column<string>(maxLength: 50, nullable: false),
                    StartYear = table.Column<int>(nullable: false),
                    EndMonth = table.Column<string>(maxLength: 50, nullable: false),
                    EndYear = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.StudyId);
                    table.ForeignKey(
                        name: "FK_Studies_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Company = table.Column<string>(maxLength: 100, nullable: false),
                    StartMonth = table.Column<string>(maxLength: 50, nullable: false),
                    StartYear = table.Column<int>(nullable: false),
                    EndMonth = table.Column<string>(maxLength: 50, nullable: false),
                    EndYear = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    Id_Curriculum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Curriculum_Id_Curriculum",
                        column: x => x.Id_Curriculum,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_Id_Curriculum",
                table: "Certificates",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Id_Template",
                table: "Curriculum",
                column: "Id_Template");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Id_User",
                table: "Curriculum",
                column: "Id_User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomSections_Id_Curriculum",
                table: "CustomSections",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_Id_Curriculum",
                table: "Interests",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Id_Curriculum",
                table: "Languages",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_Id_Curriculum",
                table: "PersonalDetails",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalReferences_Id_Curriculum",
                table: "PersonalReferences",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Id_Curriculum",
                table: "Skills",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_Studies_Id_Curriculum",
                table: "Studies",
                column: "Id_Curriculum");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_Id_Curriculum",
                table: "WorkExperiences",
                column: "Id_Curriculum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CustomSections");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "PersonalReferences");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Studies");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

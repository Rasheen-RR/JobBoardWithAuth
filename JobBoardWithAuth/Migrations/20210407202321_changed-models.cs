﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoardWithAuth.Migrations
{
    public partial class changedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CoverLetter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CandidateEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_Candidate_CandidateEmail",
                        column: x => x.CandidateEmail,
                        principalTable: "Candidate",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPosting",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    JobFunction = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    Responsibilities = table.Column<string>(nullable: true),
                    Qualifications = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    EmployerEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosting", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobPosting_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobPosting_Employer_EmployerEmail",
                        column: x => x.EmployerEmail,
                        principalTable: "Employer",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(nullable: true),
                    EducationType = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ResumeEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Education_Resume_ResumeEmail",
                        column: x => x.ResumeEmail,
                        principalTable: "Resume",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    WorkDone = table.Column<string>(nullable: true),
                    ResumeEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experience_Resume_ResumeEmail",
                        column: x => x.ResumeEmail,
                        principalTable: "Resume",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    JobApplicationId = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    jobPostingJobId = table.Column<Guid>(nullable: true),
                    applicantId = table.Column<string>(nullable: true),
                    candidateEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.JobApplicationId);
                    table.ForeignKey(
                        name: "FK_JobApplication_Candidate_candidateEmail",
                        column: x => x.candidateEmail,
                        principalTable: "Candidate",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplication_JobPosting_jobPostingJobId",
                        column: x => x.jobPostingJobId,
                        principalTable: "JobPosting",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedSearch",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CandidateEmail = table.Column<string>(nullable: true),
                    JobId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedSearch", x => x.SaveId);
                    table.ForeignKey(
                        name: "FK_SavedSearch_Candidate_CandidateEmail",
                        column: x => x.CandidateEmail,
                        principalTable: "Candidate",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedSearch_JobPosting_JobId",
                        column: x => x.JobId,
                        principalTable: "JobPosting",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_ResumeEmail",
                table: "Education",
                column: "ResumeEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ResumeEmail",
                table: "Experience",
                column: "ResumeEmail");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_candidateEmail",
                table: "JobApplication",
                column: "candidateEmail");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_jobPostingJobId",
                table: "JobApplication",
                column: "jobPostingJobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosting_CompanyId",
                table: "JobPosting",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosting_EmployerEmail",
                table: "JobPosting",
                column: "EmployerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CandidateEmail",
                table: "Notification",
                column: "CandidateEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CompanyId",
                table: "Notification",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSearch_CandidateEmail",
                table: "SavedSearch",
                column: "CandidateEmail");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSearch_JobId",
                table: "SavedSearch",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "SavedSearch");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "JobPosting");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}

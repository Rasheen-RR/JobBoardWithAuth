using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoardWithAuth.Migrations
{
    public partial class changedmodelsemployer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosting_Company_CompanyId",
                table: "JobPosting");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Candidate_CandidateEmail",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Company_CompanyId",
                table: "Notification");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Notification_CandidateEmail",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_CompanyId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_JobPosting_CompanyId",
                table: "JobPosting");

            migrationBuilder.DropColumn(
                name: "CandidateEmail",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobPosting");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Notification",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "Notification",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CandidateId",
                table: "Notification",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Candidate_CandidateId",
                table: "Notification",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Candidate_CandidateId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_CandidateId",
                table: "Notification");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateEmail",
                table: "Notification",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "JobPosting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CandidateEmail",
                table: "Notification",
                column: "CandidateEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CompanyId",
                table: "Notification",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosting_CompanyId",
                table: "JobPosting",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosting_Company_CompanyId",
                table: "JobPosting",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Candidate_CandidateEmail",
                table: "Notification",
                column: "CandidateEmail",
                principalTable: "Candidate",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Company_CompanyId",
                table: "Notification",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Results_ResultId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Results_ResultId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Results_ExamId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ResultId",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Certificates",
                newName: "Certificate");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_ResultId",
                table: "Certificate",
                newName: "IX_Certificate_ResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ExamId",
                table: "Results",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Results_ResultId",
                table: "Certificate",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "ResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Results_ResultId",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Results_ExamId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate");

            migrationBuilder.RenameTable(
                name: "Certificate",
                newName: "Certificates");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_ResultId",
                table: "Certificates",
                newName: "IX_Certificates_ResultId");

            migrationBuilder.AddColumn<Guid>(
                name: "ResultId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ExamId",
                table: "Results",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ResultId",
                table: "Exams",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Results_ResultId",
                table: "Certificates",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Results_ResultId",
                table: "Exams",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "ResultId");
        }
    }
}

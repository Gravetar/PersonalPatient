using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Patient.Migrations
{
    public partial class Patient1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_patient",
                table: "appointments",
                newName: "patientid");

            migrationBuilder.RenameColumn(
                name: "id_doctor",
                table: "appointments",
                newName: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctorid",
                table: "appointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patientid",
                table: "appointments",
                column: "patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments",
                column: "doctorid",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patientid",
                table: "appointments",
                column: "patientid",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientid",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctorid",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_patientid",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "patientid",
                table: "appointments",
                newName: "id_patient");

            migrationBuilder.RenameColumn(
                name: "doctorid",
                table: "appointments",
                newName: "id_doctor");
        }
    }
}

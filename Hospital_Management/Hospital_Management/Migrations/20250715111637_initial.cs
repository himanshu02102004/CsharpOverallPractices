using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emailSettings",
                columns: table => new
                {
                    FromEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmptHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmptPort = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailSettings", x => x.FromEmail);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patient_phoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Appoitment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Doctor_Id = table.Column<int>(type: "int", nullable: false),
                    Appointment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_id1 = table.Column<int>(type: "int", nullable: false),
                    Doctor_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Appoitment_Id);
                    table.ForeignKey(
                        name: "FK_appointments_Patients_Patient_id1",
                        column: x => x.Patient_id1,
                        principalTable: "Patients",
                        principalColumn: "Patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    appointmentAppoitment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Department_Id);
                    table.ForeignKey(
                        name: "FK_departments_appointments_appointmentAppoitment_Id",
                        column: x => x.appointmentAppoitment_Id,
                        principalTable: "appointments",
                        principalColumn: "Appoitment_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Doctor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    availability_slot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsonLeave = table.Column<bool>(type: "bit", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false),
                    Department_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Doctor_Id);
                    table.ForeignKey(
                        name: "FK_doctors_departments_Department_Id1",
                        column: x => x.Department_Id1,
                        principalTable: "departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Doctor_Id = table.Column<int>(type: "int", nullable: false),
                    Appoitment_Id = table.Column<int>(type: "int", nullable: false),
                    Doctor_Id1 = table.Column<int>(type: "int", nullable: false),
                    Patient_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescriptions_Patients_Patient_id1",
                        column: x => x.Patient_id1,
                        principalTable: "Patients",
                        principalColumn: "Patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescriptions_appointments_Appoitment_Id",
                        column: x => x.Appoitment_Id,
                        principalTable: "appointments",
                        principalColumn: "Appoitment_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prescriptions_doctors_Doctor_Id1",
                        column: x => x.Doctor_Id1,
                        principalTable: "doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_Doctor_Id1",
                table: "appointments",
                column: "Doctor_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_Patient_id1",
                table: "appointments",
                column: "Patient_id1");

            migrationBuilder.CreateIndex(
                name: "IX_departments_appointmentAppoitment_Id",
                table: "departments",
                column: "appointmentAppoitment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_Department_Id1",
                table: "doctors",
                column: "Department_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_Appoitment_Id",
                table: "prescriptions",
                column: "Appoitment_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_Doctor_Id1",
                table: "prescriptions",
                column: "Doctor_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_Patient_id1",
                table: "prescriptions",
                column: "Patient_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_Doctor_Id1",
                table: "appointments",
                column: "Doctor_Id1",
                principalTable: "doctors",
                principalColumn: "Doctor_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Patients_Patient_id1",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_Doctor_Id1",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "Auditlogs");

            migrationBuilder.DropTable(
                name: "emailSettings");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "appointments");
        }
    }
}

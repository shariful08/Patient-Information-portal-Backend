using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Information_portal_Back_end.Migrations
{
    /// <inheritdoc />
    public partial class AddingPatientInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientsInformation",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseasesName = table.Column<int>(type: "int", nullable: false),
                    Epilepsy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NCD = table.Column<int>(type: "int", nullable: false),
                    Allergies = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsInformation", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientsInformation");
        }
    }
}

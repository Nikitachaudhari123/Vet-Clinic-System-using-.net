using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vet_Clinic.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VetDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetDoctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MicrochipId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VetDoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_VetDoctors_VetDoctorId",
                        column: x => x.VetDoctorId,
                        principalTable: "VetDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    VetNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetProfiles_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VetDoctors",
                columns: new[] { "Id", "Name", "Specialty" },
                values: new object[,]
                {
                    { 1, "Dr. Alice", "Dogs" },
                    { 2, "Dr. Bob", "Cats" },
                    { 3, "Dr. Maria", "Birds & Exotics" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "MicrochipId", "Name", "Species", "VetDoctorId" },
                values: new object[,]
                {
                    { 1, "MC001", "Buddy", "Dog", 1 },
                    { 2, "MC002", "Mittens", "Cat", 2 },
                    { 3, "MC003", "Luna", "Cat", 2 },
                    { 4, "MC004", "Kiwi", "Parrot", 3 }
                });

            migrationBuilder.InsertData(
                table: "PetProfiles",
                columns: new[] { "Id", "PetId", "VetNotes" },
                values: new object[,]
                {
                    { 1, 1, "Healthy. Annual checkup done." },
                    { 2, 2, "Allergy to food. Monitor diet." },
                    { 3, 3, "Vaccinated. Monitor side effects." },
                    { 4, 4, "Feathers trimmed. Follow-up in 3 months." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetProfiles_PetId",
                table: "PetProfiles",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_VetDoctorId",
                table: "Pets",
                column: "VetDoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetProfiles");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "VetDoctors");
        }
    }
}

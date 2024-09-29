using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackingEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadInKg = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingEntries_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bench Press" },
                    { 2, "Barbell Squat" },
                    { 3, "Barbell Deadlift" }
                });

            migrationBuilder.InsertData(
                table: "TrackingEntries",
                columns: new[] { "Id", "Date", "ExerciseId", "LoadInKg", "Reps", "Sets" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 28, 21, 22, 46, 433, DateTimeKind.Local).AddTicks(1081), 1, 80, 10, 3 },
                    { 2, new DateTime(2024, 9, 28, 21, 22, 46, 433, DateTimeKind.Local).AddTicks(1123), 2, 100, 8, 3 },
                    { 3, new DateTime(2024, 9, 28, 21, 22, 46, 433, DateTimeKind.Local).AddTicks(1125), 3, 120, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackingEntries_ExerciseId",
                table: "TrackingEntries",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingEntries");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}

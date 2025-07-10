using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsekReader.API.Migrations
{
    /// <inheritdoc />
    public partial class FixMeterReadingKeyAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeterReadings",
                table: "MeterReadings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeterReadings",
                table: "MeterReadings",
                columns: new[] { "AccountId", "MeterReadingDateTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeterReadings",
                table: "MeterReadings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeterReadings",
                table: "MeterReadings",
                column: "MeterReadingDateTime");
        }
    }
}

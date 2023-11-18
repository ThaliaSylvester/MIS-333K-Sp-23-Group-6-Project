using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group6FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Setup123456 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalNumberofSeats",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNumberofSeats",
                table: "Transactions");
        }
    }
}

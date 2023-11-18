using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group6FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Setup1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeniorTicket",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "TuesdayTicket",
                table: "TransactionDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SeniorTicket",
                table: "TransactionDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TuesdayTicket",
                table: "TransactionDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

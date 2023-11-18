using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group6FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Setup123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoredTotal",
                table: "Transactions",
                newName: "TransactionTotal");

            migrationBuilder.RenameColumn(
                name: "StoredTax",
                table: "Transactions",
                newName: "TransactionTax");

            migrationBuilder.RenameColumn(
                name: "StoredSubtotal",
                table: "Transactions",
                newName: "PopcornPoints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionTotal",
                table: "Transactions",
                newName: "StoredTotal");

            migrationBuilder.RenameColumn(
                name: "TransactionTax",
                table: "Transactions",
                newName: "StoredTax");

            migrationBuilder.RenameColumn(
                name: "PopcornPoints",
                table: "Transactions",
                newName: "StoredSubtotal");
        }
    }
}

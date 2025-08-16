using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestãoFinancas.Migrations
{
    /// <inheritdoc />
    public partial class AddValueToExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Expenses",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Expenses");
        }
    }
}

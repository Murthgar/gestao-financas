using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestãoFinancas.Migrations
{
    /// <inheritdoc />
    public partial class AddRecurrenceFieldsToExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndRecurrence",
                table: "Expenses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "Expenses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceType",
                table: "Expenses",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndRecurrence",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RecurrenceType",
                table: "Expenses");
        }
    }
}

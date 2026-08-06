using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLedgerPostingRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Particulars",
                table: "LedgerPostingDetails",
                newName: "Narration");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "LedgerPostings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "LedgerPostings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LedgerPostings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "LedgerPostings");

            migrationBuilder.RenameColumn(
                name: "Narration",
                table: "LedgerPostingDetails",
                newName: "Particulars");
        }
    }
}

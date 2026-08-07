using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixLedgerNavigationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerPostingDetails_Ledgers_LedgerId",
                table: "LedgerPostingDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerPostingDetails_Ledgers_LedgerId",
                table: "LedgerPostingDetails",
                column: "LedgerId",
                principalTable: "Ledgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerPostingDetails_Ledgers_LedgerId",
                table: "LedgerPostingDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerPostingDetails_Ledgers_LedgerId",
                table: "LedgerPostingDetails",
                column: "LedgerId",
                principalTable: "Ledgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

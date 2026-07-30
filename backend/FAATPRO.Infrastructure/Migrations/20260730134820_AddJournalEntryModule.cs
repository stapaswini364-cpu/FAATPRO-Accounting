using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJournalEntryModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VoucherNo = table.Column<string>(type: "text", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReferenceNo = table.Column<string>(type: "text", nullable: true),
                    Narration = table.Column<string>(type: "text", nullable: true),
                    TotalDebit = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "numeric", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FinancialYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JournalEntryId = table.Column<Guid>(type: "uuid", nullable: false),
                    LedgerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Debit = table.Column<decimal>(type: "numeric", nullable: false),
                    Credit = table.Column<decimal>(type: "numeric", nullable: false),
                    Narration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntryDetails_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntryDetails_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "Ledgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_VoucherNo",
                table: "JournalEntries",
                column: "VoucherNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryDetails_JournalEntryId",
                table: "JournalEntryDetails",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryDetails_LedgerId",
                table: "JournalEntryDetails",
                column: "LedgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntryDetails");

            migrationBuilder.DropTable(
                name: "JournalEntries");
        }
    }
}

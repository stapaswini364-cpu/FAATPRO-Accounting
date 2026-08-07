using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVoucherTypeRelationToJournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoucherTypeId",
                table: "JournalEntries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_VoucherTypeId",
                table: "JournalEntries",
                column: "VoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_VoucherTypes_VoucherTypeId",
                table: "JournalEntries",
                column: "VoucherTypeId",
                principalTable: "VoucherTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_VoucherTypes_VoucherTypeId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_VoucherTypeId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "VoucherTypeId",
                table: "JournalEntries");
        }
    }
}

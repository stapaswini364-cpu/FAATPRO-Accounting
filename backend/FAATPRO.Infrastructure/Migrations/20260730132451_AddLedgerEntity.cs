using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLedgerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GSTNo",
                table: "Ledgers",
                newName: "GSTIN");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubGroupId",
                table: "Ledgers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountGroupId",
                table: "Ledgers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountHeadId",
                table: "Ledgers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_AccountGroupId",
                table: "Ledgers",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_AccountHeadId",
                table: "Ledgers",
                column: "AccountHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ledgers_AccountGroups_AccountGroupId",
                table: "Ledgers",
                column: "AccountGroupId",
                principalTable: "AccountGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ledgers_AccountHeads_AccountHeadId",
                table: "Ledgers",
                column: "AccountHeadId",
                principalTable: "AccountHeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ledgers_AccountGroups_AccountGroupId",
                table: "Ledgers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledgers_AccountHeads_AccountHeadId",
                table: "Ledgers");

            migrationBuilder.DropIndex(
                name: "IX_Ledgers_AccountGroupId",
                table: "Ledgers");

            migrationBuilder.DropIndex(
                name: "IX_Ledgers_AccountHeadId",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "AccountGroupId",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "AccountHeadId",
                table: "Ledgers");

            migrationBuilder.RenameColumn(
                name: "GSTIN",
                table: "Ledgers",
                newName: "GSTNo");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountSubGroupId",
                table: "Ledgers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}

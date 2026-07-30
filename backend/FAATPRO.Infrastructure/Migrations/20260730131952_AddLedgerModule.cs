using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLedgerModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ledgers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AccountSubGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    BalanceType = table.Column<int>(type: "integer", nullable: false),
                    GSTNo = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ledgers_AccountSubGroups_AccountSubGroupId",
                        column: x => x.AccountSubGroupId,
                        principalTable: "AccountSubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_AccountSubGroupId",
                table: "Ledgers",
                column: "AccountSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Code",
                table: "Ledgers",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledgers");
        }
    }
}

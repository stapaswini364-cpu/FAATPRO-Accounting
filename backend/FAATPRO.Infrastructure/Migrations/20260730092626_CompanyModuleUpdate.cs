using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAATPRO.Infrastructure.Migrations
{
    public partial class CompanyModuleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Companies");


            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Companies",
                newName: "CreatedAt");



            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Companies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);



            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Companies",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);



            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Companies",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);



            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Companies",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);



            migrationBuilder.AlterColumn<string>(
                name: "PANNumber",
                table: "Companies",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);



            migrationBuilder.AlterColumn<string>(
                name: "LegalName",
                table: "Companies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);



            migrationBuilder.AlterColumn<string>(
                name: "GSTNumber",
                table: "Companies",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);



            // FIXED: string -> integer conversion
            migrationBuilder.Sql(
                """
                ALTER TABLE "Companies"
                ALTER COLUMN "FinancialYearStartMonth"
                TYPE integer
                USING NULLIF("FinancialYearStartMonth",'')::integer;
                """
            );



            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);



            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Companies",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);



            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Companies",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);



            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Companies",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);



            migrationBuilder.AlterColumn<string>(
                name: "CINNumber",
                table: "Companies",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);



            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Companies",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);



            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Companies",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Companies",
                newName: "CreatedOn");


            migrationBuilder.Sql(
                """
                ALTER TABLE "Companies"
                ALTER COLUMN "FinancialYearStartMonth"
                TYPE character varying(20)
                USING "FinancialYearStartMonth"::text;
                """
            );


            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");


            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);


            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);


            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Companies",
                type: "text",
                nullable: true);


            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
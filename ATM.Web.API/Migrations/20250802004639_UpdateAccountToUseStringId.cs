using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountToUseStringId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraint first
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "TransferAccountId",
                table: "Transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            // Recreate the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id",
                table: "Accounts",
                column: "Id",
                unique: true);

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraint first
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Id",
                table: "Accounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransferAccountId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            // Recreate the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Accounts",
                column: "AccountNumber",
                unique: true);

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

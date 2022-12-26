using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlifTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class allowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_FromWalletId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_FromWalletId",
                table: "Transactions",
                column: "FromWalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_FromWalletId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_FromWalletId",
                table: "Transactions",
                column: "FromWalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

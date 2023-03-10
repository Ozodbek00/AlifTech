using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlifTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class transactionFrom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Transactions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Transactions");
        }
    }
}

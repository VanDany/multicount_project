using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multicountAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionsUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsUsers_LocalUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionsUsers_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 12, 7, 599, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 12, 7, 599, DateTimeKind.Local).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 12, 7, 599, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 12, 7, 599, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 12, 7, 599, DateTimeKind.Local).AddTicks(2704));

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsUsers_UserId",
                table: "TransactionsUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionsUsers");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 7, 0, 66, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 7, 0, 66, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 7, 0, 66, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 7, 0, 66, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 7, 0, 66, DateTimeKind.Local).AddTicks(7250));
        }
    }
}

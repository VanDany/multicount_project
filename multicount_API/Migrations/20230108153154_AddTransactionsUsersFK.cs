using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multicountAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionsUsersFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 31, 54, 193, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 31, 54, 193, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 31, 54, 193, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 31, 54, 193, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 31, 54, 193, DateTimeKind.Local).AddTicks(2684));

            //migrationBuilder.CreateIndex(
            //    name: "IX_TransactionsUsers_TransactionId",
            //    table: "TransactionsUsers",
            //    column: "TransactionId",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers");

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
        }
    }
}

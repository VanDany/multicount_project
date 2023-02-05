using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multicountAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "GroupId" },
                values: new object[] { new DateTime(2023, 2, 5, 16, 9, 57, 27, DateTimeKind.Local).AddTicks(9363), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "GroupId" },
                values: new object[] { new DateTime(2023, 2, 5, 16, 9, 57, 27, DateTimeKind.Local).AddTicks(9394), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "GroupId" },
                values: new object[] { new DateTime(2023, 2, 5, 16, 9, 57, 27, DateTimeKind.Local).AddTicks(9395), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "GroupId" },
                values: new object[] { new DateTime(2023, 2, 5, 16, 9, 57, 27, DateTimeKind.Local).AddTicks(9397), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "GroupId" },
                values: new object[] { new DateTime(2023, 2, 5, 16, 9, 57, 27, DateTimeKind.Local).AddTicks(9398), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "GroupsUsers");

            migrationBuilder.DropIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Transactions");

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

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsUsers_TransactionId",
                table: "TransactionsUsers",
                column: "TransactionId",
                unique: true);
        }
    }
}

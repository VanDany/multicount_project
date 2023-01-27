using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multicountAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 1, 8, 12, 34, 17, 96, DateTimeKind.Local).AddTicks(199), "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 1, 8, 12, 34, 17, 96, DateTimeKind.Local).AddTicks(231), "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 1, 8, 12, 34, 17, 96, DateTimeKind.Local).AddTicks(233), "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 1, 8, 12, 34, 17, 96, DateTimeKind.Local).AddTicks(234), "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2023, 1, 8, 12, 34, 17, 96, DateTimeKind.Local).AddTicks(236), "e86d0b76 - d3d6 - 4b1a - aca5 - d226ea2554b0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 7, 17, 30, 1, 194, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 7, 17, 30, 1, 194, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 7, 17, 30, 1, 194, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 7, 17, 30, 1, 194, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 7, 17, 30, 1, 194, DateTimeKind.Local).AddTicks(6209));
        }
    }
}

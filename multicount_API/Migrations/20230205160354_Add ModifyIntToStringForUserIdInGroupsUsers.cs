using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multicountAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddModifyIntToStringForUserIdInGroupsUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GroupsUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 17, 3, 53, 829, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 17, 3, 53, 829, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 17, 3, 53, 829, DateTimeKind.Local).AddTicks(9904));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 17, 3, 53, 829, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 17, 3, 53, 829, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_GroupId",
                table: "GroupsUsers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Groups_GroupId",
                table: "GroupsUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsUsers_Groups_GroupId",
                table: "GroupsUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupsUsers_GroupId",
                table: "GroupsUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GroupsUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 16, 35, 28, 889, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 16, 35, 28, 889, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 16, 35, 28, 889, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 16, 35, 28, 889, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 5, 16, 35, 28, 889, DateTimeKind.Local).AddTicks(2480));
        }
    }
}

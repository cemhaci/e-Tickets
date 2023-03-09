using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Tickets.Migrations
{
    public partial class picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 4, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(838), new DateTime(2023, 1, 28, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 1, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(845), new DateTime(2023, 1, 28, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 31, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(847), new DateTime(2023, 1, 28, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 7, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(849), new DateTime(2023, 1, 28, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(848) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 7, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(851), new DateTime(2023, 1, 28, 18, 0, 3, 621, DateTimeKind.Local).AddTicks(850) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 4, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7024), new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 1, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7031), new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7031) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 31, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7033), new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7033) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 7, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7035), new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7035) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 7, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7037), new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7037) });
        }
    }
}

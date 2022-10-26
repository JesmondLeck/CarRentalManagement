using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalManagement.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "4d30293d-473c-4507-8c76-af859c371104");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "4bfc7af6-1752-4be5-bce8-3d0e78568285");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "firstName", "lastName" },
                values: new object[] { "6cc26851-23e1-4608-af1a-1fa21be4e183", "AQAAAAEAACcQAAAAEOnt1Jcm1UXkfP+oK3P0pRhIzYfEGYC6XPk+wxy/du8Oxy2AjZhg9Pba29jE0qmUUg==", "9593e987-5de1-46c5-8b94-6f944a64bcd3", "Admin", "User" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 976, DateTimeKind.Local).AddTicks(5630), new DateTime(2022, 10, 26, 9, 37, 26, 979, DateTimeKind.Local).AddTicks(5391) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 979, DateTimeKind.Local).AddTicks(5912), new DateTime(2022, 10, 26, 9, 37, 26, 979, DateTimeKind.Local).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(4112), new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(4121), new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6372), new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6378), new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6378) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6380), new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6381), new DateTime(2022, 10, 26, 9, 37, 26, 980, DateTimeKind.Local).AddTicks(6382) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "cba571a2-4ff6-4044-8dbb-06410a23d164");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "b866b1bc-7a22-4d15-86cb-1e01a70d2a4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "firstName", "lastName" },
                values: new object[] { "93113deb-2acd-40a3-94a0-7e1a44936485", "AQAAAAEAACcQAAAAEHnNStVT34z2huV8HNo4OHhBDIxE+9zgPxC2edyj2b9xEzHWY+kulZoAE0FqmZwZxQ==", "8aa8786a-d304-4144-a8c7-9c96d2de7330", null, null });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 109, DateTimeKind.Local).AddTicks(8064), new DateTime(2022, 10, 26, 9, 28, 58, 113, DateTimeKind.Local).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 113, DateTimeKind.Local).AddTicks(6470), new DateTime(2022, 10, 26, 9, 28, 58, 113, DateTimeKind.Local).AddTicks(6473) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(5694), new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(5703) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(5706), new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(5707) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8513), new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8514) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8515), new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8517), new DateTime(2022, 10, 26, 9, 28, 58, 114, DateTimeKind.Local).AddTicks(8517) });
        }
    }
}

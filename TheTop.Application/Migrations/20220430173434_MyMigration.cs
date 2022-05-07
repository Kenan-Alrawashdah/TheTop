using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTop.Application.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accountant-role-id",
                column: "ConcurrencyStamp",
                value: "e37c2ae8-607a-43cd-8934-5486114f953a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "cdcc9549-0e68-4272-8aef-c39d5c3e77aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer-role-id",
                column: "ConcurrencyStamp",
                value: "788ed240-2c1e-446e-a70e-a10bbc5ca947");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Programmer-role-id",
                column: "ConcurrencyStamp",
                value: "ce977a7a-2c7e-457e-abaa-3bd8e85a06cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "administrator-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84b9c131-8352-4d62-a84b-c9a759b0578c", "AQAAAAEAACcQAAAAEBV3y+Yjj0iIwFZaY2BXPfAqVDFORm2+d9eL2tNC5j29KKjVlY3DHSg+Y0U0HjQ3hQ==", "a6ca5bc7-d828-437d-9469-88562669da26" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accountant-role-id",
                column: "ConcurrencyStamp",
                value: "ca9f552d-44d8-43a2-a78a-4a342d342d84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "21ad13de-f83b-42f2-901a-d0d988852e9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer-role-id",
                column: "ConcurrencyStamp",
                value: "b3398767-28f1-4cfe-b31f-3197f9bdcdd2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Programmer-role-id",
                column: "ConcurrencyStamp",
                value: "f32d4cad-d7fd-4585-abd1-85e3fbe50378");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "administrator-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c056389-4ac0-430d-b5e3-c2f3311e9986", "AQAAAAEAACcQAAAAEP6yRE8M+87eWA28hh5SDL139+GDSzeg2kqcZZNyl8EzOJ1Y/RH1lJucKxoiXpZ40w==", "7400978b-5d00-4aec-b2a7-d6288a397cfe" });
        }
    }
}

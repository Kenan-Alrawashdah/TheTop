using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTop.Application.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_ApplicationUserId",
                table: "Works");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_ApplicationUserId",
                table: "Works",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_ApplicationUserId",
                table: "Works");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accountant-role-id",
                column: "ConcurrencyStamp",
                value: "cb07f423-64ca-450e-87ea-ad93afad812e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "41990b45-627c-4ea3-a6fa-dfc41ffc8313");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer-role-id",
                column: "ConcurrencyStamp",
                value: "732bd4e3-7624-4955-a383-977e45c53c0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Programmer-role-id",
                column: "ConcurrencyStamp",
                value: "403ef62e-7bbf-4cb6-b0d2-ed1cb06944d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "administrator-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "617b5f1d-3350-4b40-8c8e-71ac7f798076", "AQAAAAEAACcQAAAAEHbm9pW9vNaezaQoKyHVh7scw0tYhCv8pYMISwzHUUv+Srp9mh5sTI+/PWVCcP53xQ==", "48ad0a83-287e-454c-ab89-c7ac11221244" });

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_ApplicationUserId",
                table: "Works",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTop.Application.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntities_AspNetUsers_ApplicationUserId",
                table: "TaskEntities");

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
                name: "FK_TaskEntities_AspNetUsers_ApplicationUserId",
                table: "TaskEntities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntities_AspNetUsers_ApplicationUserId",
                table: "TaskEntities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accountant-role-id",
                column: "ConcurrencyStamp",
                value: "55bd6b21-613b-4391-bba9-8e46d798492e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id",
                column: "ConcurrencyStamp",
                value: "ea9fc783-0ca1-4461-a1ba-83dd89cd1d28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer-role-id",
                column: "ConcurrencyStamp",
                value: "9ac9a647-3db3-454c-a4a5-66e586cc5a63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Programmer-role-id",
                column: "ConcurrencyStamp",
                value: "25d17dad-ab99-4d9c-8f1d-0b95f8bad0b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "administrator-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6965deb0-5e45-4e9c-a7bf-e6c56856f258", "AQAAAAEAACcQAAAAECYmmFNJJFvMf8CM8o87v0Dqn/72uapwlpnY1i8eUZEPp/xD8WQVdjXMJ68G6+VKPg==", "defedf30-05c4-42c9-8279-d7d8dd57d6bc" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntities_AspNetUsers_ApplicationUserId",
                table: "TaskEntities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

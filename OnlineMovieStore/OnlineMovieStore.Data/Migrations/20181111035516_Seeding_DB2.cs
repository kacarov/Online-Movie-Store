using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieStore.Data.Migrations
{
    public partial class Seeding_DB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", "6545cbd4-fbf2-4c0a-9681-89e401781ad5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c72ebfa8-9623-4602-9b6e-329ecd722628", 0, 0.0, "423b4b97-a2c1-4431-bec4-b9666a84624a", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMINMAIN", "AQAAAAEAACcQAAAAEIbhjDqWH4lt52DVQyyEclfkP83jZL5Hk3v0d5p7J68sApnjm/CzBd49Ro8ZL97BXQ==", "+111111111", true, "1dea36c8-5b21-4c6d-bd65-21353bcf0861", false, "VksAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c72ebfa8-9623-4602-9b6e-329ecd722628", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c72ebfa8-9623-4602-9b6e-329ecd722628", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c72ebfa8-9623-4602-9b6e-329ecd722628", "423b4b97-a2c1-4431-bec4-b9666a84624a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", 0, 0.0, "6545cbd4-fbf2-4c0a-9681-89e401781ad5", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMINMAIN", "AQAAAAEAACcQAAAAECk4ynnDQ+/jNKUNEHwL379ldVHSi7WO3lAiZuBDLil9CR9ltQLCRPbUYANUzbsMMA==", "+111111111", true, "bc2b4a8f-1d26-4055-9277-b29962ef70b4", false, "adminMain" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", "1" });
        }
    }
}

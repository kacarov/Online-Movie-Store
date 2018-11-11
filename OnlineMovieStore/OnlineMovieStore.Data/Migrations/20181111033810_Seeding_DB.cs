using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieStore.Data.Migrations
{
    public partial class Seeding_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "aaa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "bbb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", 0, 0.0, "6545cbd4-fbf2-4c0a-9681-89e401781ad5", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMINMAIN", "AQAAAAEAACcQAAAAECk4ynnDQ+/jNKUNEHwL379ldVHSi7WO3lAiZuBDLil9CR9ltQLCRPbUYANUzbsMMA==", "+111111111", true, "bc2b4a8f-1d26-4055-9277-b29962ef70b4", false, "adminMain" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2", "bbb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1", "aaa" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4be9c1d1-cfb3-432f-ab8d-2ee18e2f0eea", "6545cbd4-fbf2-4c0a-9681-89e401781ad5" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaM.Infrastructure.Migrations
{
    public partial class UserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aec9bf40-5990-4fe7-bac3-a543da631b54", "f434c168-2704-4afc-9345-7497e86de8a9", "User", "USER" },
                    { "f9edb0de-fda1-47b6-8932-d3cf64a7eabb", "59c79a4d-a182-4aa8-a0c7-9811c3016d13", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "180c0957-5eb9-4c4a-b0c5-90a3c609b981", 0, "", "ed276da3-8689-4410-a4eb-17c19973fcb1", "user2@hotmail.com", false, "", "", false, null, "USER2@HOTMAIL.COM", "USER2@HOTMAIL.COM", "AQAAAAEAACcQAAAAEOInAAsgyEk+50juWfbBscjCfyBa1kRSllBB9/IMC8ql06A71JImYlPyEsBufBHPTQ==", "", null, false, "e8ffd692-6d06-4726-a5bd-ed7daf67a2df", false, "user2@hotmail.com" },
                    { "70ad7c70-d2e2-41b0-80dc-d76e2622113b", 0, "", "05411263-7cf7-4633-bba6-3d823b5936c7", "user3@hotmail.com", false, "", "", false, null, "USER3@HOTMAIL.COM", "USER3@HOTMAIL.COM", "AQAAAAEAACcQAAAAEI8sdu9ABNTwGIGghxqbCJfk5B00/BFytLoT8qont4dPefAhDTq1wKsQ5SZkmUyOZg==", "", null, false, "ea14b934-13bd-4963-98d3-f4eef3912eb8", false, "user3@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aec9bf40-5990-4fe7-bac3-a543da631b54", "180c0957-5eb9-4c4a-b0c5-90a3c609b981" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f9edb0de-fda1-47b6-8932-d3cf64a7eabb", "70ad7c70-d2e2-41b0-80dc-d76e2622113b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aec9bf40-5990-4fe7-bac3-a543da631b54", "180c0957-5eb9-4c4a-b0c5-90a3c609b981" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9edb0de-fda1-47b6-8932-d3cf64a7eabb", "70ad7c70-d2e2-41b0-80dc-d76e2622113b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec9bf40-5990-4fe7-bac3-a543da631b54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9edb0de-fda1-47b6-8932-d3cf64a7eabb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "180c0957-5eb9-4c4a-b0c5-90a3c609b981");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70ad7c70-d2e2-41b0-80dc-d76e2622113b");
        }
    }
}

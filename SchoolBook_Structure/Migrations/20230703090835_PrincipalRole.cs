using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolBook_Structure.Migrations
{
    public partial class PrincipalRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "e1849c3d-f1c1-4b61-90ea-a770ef8a5c86", "PRINCIPAL" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "003eb193-7eb1-4d83-b5bd-631b9e3f13fd", "TEACHER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "017f532a-7db4-41df-9508-3af2c9d58d26", "PARENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9d3f2c67-87bf-4db3-af54-9d3ec5311810", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "5df1e708-dac1-4dc7-b984-7621bd47f8a4", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "04d434b8-d88f-4d23-848d-7e99c234fabd", "ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolBook_Structure.Migrations
{
    public partial class PrincipalRoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "9d3f2c67-87bf-4db3-af54-9d3ec5311810", "Principal" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "5df1e708-dac1-4dc7-b984-7621bd47f8a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                column: "ConcurrencyStamp",
                value: "04d434b8-d88f-4d23-848d-7e99c234fabd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "48cfae0d-d211-448b-b3ff-b84a48553ef4", "Director" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "2e03a8f8-8ad0-4d1a-974c-411649e2a2ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                column: "ConcurrencyStamp",
                value: "e028f578-f508-4488-b69d-63f9dc43304e");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolBook_Structure.Migrations
{
    public partial class dataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Exams_ExamId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "ExamStudent",
                columns: table => new
                {
                    ExamsId = table.Column<int>(type: "int", nullable: false),
                    StudentsstudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStudent", x => new { x.ExamsId, x.StudentsstudentId });
                    table.ForeignKey(
                        name: "FK_ExamStudent_Exams_ExamsId",
                        column: x => x.ExamsId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamStudent_Students_StudentsstudentId",
                        column: x => x.StudentsstudentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ft3109e-3t4e-446f-46he-085116fr7450",
                column: "ConcurrencyStamp",
                value: "cda54224-4b91-482f-a030-70785fdba753");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7145f2f3-1d68-4914-918d-870ab81ea581");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "25c3d486-4db5-4a2b-9d97-b768498192e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                column: "ConcurrencyStamp",
                value: "21ac61e5-ab7e-4b26-89cd-05f55d0260f2");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudent_StudentsstudentId",
                table: "ExamStudent",
                column: "StudentsstudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamStudent");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ft3109e-3t4e-446f-46he-085116fr7450",
                column: "ConcurrencyStamp",
                value: "041e3738-870e-47dd-86b9-4761d26ed2c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c48d86f7-be51-424f-b5e3-73699170dd3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "a2a4ea88-4c10-4895-96bd-c584eb4c348c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                column: "ConcurrencyStamp",
                value: "3ba2cf3a-d00d-4fea-98bf-cef726d8fa8c");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ExamId",
                table: "Students",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Exams_ExamId",
                table: "Students",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}

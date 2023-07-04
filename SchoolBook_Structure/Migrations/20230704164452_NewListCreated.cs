using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolBook_Structure.Migrations
{
    public partial class NewListCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disciplibe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Exams_ExamId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ft3109e-3t4e-446f-46he-085116fr7450",
                column: "ConcurrencyStamp",
                value: "9d50bce7-7e11-4174-bd9c-82c4f6f7aa32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4b190e0a-835c-4f01-8804-9406b92085c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c93174e-3b0e-446f-86af-883d56fr7210",
                column: "ConcurrencyStamp",
                value: "d04abccc-308b-4649-8ea4-c7ee26517c39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3j99004e-3b0e-446f-86af-073p96de6410",
                column: "ConcurrencyStamp",
                value: "de0b36b8-302b-4370-ad10-70da3a277dac");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculatorApp.Data.Migrations
{
    public partial class addsubmittedcalculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmittedCalculation",
                columns: table => new
                {
                    SubmittedCalculationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Expression = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedCalculation", x => x.SubmittedCalculationId);
                    table.ForeignKey(
                        name: "FK_SubmittedCalculation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedCalculation_UserId",
                table: "SubmittedCalculation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmittedCalculation");
        }
    }
}

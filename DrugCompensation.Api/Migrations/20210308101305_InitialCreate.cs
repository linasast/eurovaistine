using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugCompensation.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compensations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DiscountFormula = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compensations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetailPrice = table.Column<double>(type: "float", nullable: false),
                    BasicCompensationPrice = table.Column<double>(type: "float", nullable: false),
                    CompensationPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompensationRecords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrugID = table.Column<int>(type: "int", nullable: true),
                    PayableSum = table.Column<double>(type: "float", nullable: false),
                    CompensationTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompensationRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompensationRecords_Compensations_CompensationTypeID",
                        column: x => x.CompensationTypeID,
                        principalTable: "Compensations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompensationRecords_Drugs_DrugID",
                        column: x => x.DrugID,
                        principalTable: "Drugs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompensationRecords_CompensationTypeID",
                table: "CompensationRecords",
                column: "CompensationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CompensationRecords_DrugID",
                table: "CompensationRecords",
                column: "DrugID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompensationRecords");

            migrationBuilder.DropTable(
                name: "Compensations");

            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notingham.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cik = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentManagerStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cik = table.Column<string>(nullable: true),
                    PeriodDate = table.Column<DateTime>(nullable: false),
                    TickerCusip = table.Column<string>(nullable: true),
                    NameOfIssuer = table.Column<string>(nullable: true),
                    Shares = table.Column<int>(nullable: false),
                    TitleOfClass = table.Column<string>(nullable: true),
                    ValueOfShares = table.Column<int>(nullable: false),
                    LinkToMain = table.Column<string>(nullable: true),
                    LinkToFinal = table.Column<string>(nullable: true),
                    InvestmentManagerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentManagerStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentManagerStocks_InvestmentManagers_InvestmentManagerId",
                        column: x => x.InvestmentManagerId,
                        principalTable: "InvestmentManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentManagerStocks_InvestmentManagerId",
                table: "InvestmentManagerStocks",
                column: "InvestmentManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentManagerStocks");

            migrationBuilder.DropTable(
                name: "InvestmentManagers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Programmeringsoppgave.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meter_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Customer_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Resolution = table.Column<string>(type: "varchar(10)", nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Values = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMeasure", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMeasure");
        }
    }
}

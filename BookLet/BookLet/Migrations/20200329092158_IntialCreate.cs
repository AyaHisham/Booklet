using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLet.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookLet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookLetSales",
                columns: table => new
                {
                    Serial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    BookLitId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    BookLetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLetSales", x => x.Serial);
                    table.ForeignKey(
                        name: "FK_BookLetSales_BookLet_BookLetId",
                        column: x => x.BookLetId,
                        principalTable: "BookLet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLetSales_BookLetId",
                table: "BookLetSales",
                column: "BookLetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLetSales");

            migrationBuilder.DropTable(
                name: "BookLet");
        }
    }
}

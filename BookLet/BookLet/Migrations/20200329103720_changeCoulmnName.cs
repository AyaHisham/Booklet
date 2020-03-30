using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLet.Migrations
{
    public partial class changeCoulmnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLetSales_BookLet_BookLetId",
                table: "BookLetSales");

            migrationBuilder.DropColumn(
                name: "BookLitId",
                table: "BookLetSales");

            migrationBuilder.AlterColumn<int>(
                name: "BookLetId",
                table: "BookLetSales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLetSales_BookLet_BookLetId",
                table: "BookLetSales",
                column: "BookLetId",
                principalTable: "BookLet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLetSales_BookLet_BookLetId",
                table: "BookLetSales");

            migrationBuilder.AlterColumn<int>(
                name: "BookLetId",
                table: "BookLetSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookLitId",
                table: "BookLetSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLetSales_BookLet_BookLetId",
                table: "BookLetSales",
                column: "BookLetId",
                principalTable: "BookLet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

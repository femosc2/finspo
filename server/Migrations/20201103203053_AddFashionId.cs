using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddFashionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothing_Fashion_FashionId",
                table: "Clothing");

            migrationBuilder.AlterColumn<int>(
                name: "FashionId",
                table: "Clothing",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothing_Fashion_FashionId",
                table: "Clothing",
                column: "FashionId",
                principalTable: "Fashion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothing_Fashion_FashionId",
                table: "Clothing");

            migrationBuilder.AlterColumn<int>(
                name: "FashionId",
                table: "Clothing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Clothing_Fashion_FashionId",
                table: "Clothing",
                column: "FashionId",
                principalTable: "Fashion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

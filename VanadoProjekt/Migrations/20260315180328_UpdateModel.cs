using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VanadoProjekt.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kvarovi_Strojevi_StrojId",
                table: "Kvarovi");

            migrationBuilder.AlterColumn<int>(
                name: "StrojId",
                table: "Kvarovi",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kvarovi_Strojevi_StrojId",
                table: "Kvarovi",
                column: "StrojId",
                principalTable: "Strojevi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kvarovi_Strojevi_StrojId",
                table: "Kvarovi");

            migrationBuilder.AlterColumn<int>(
                name: "StrojId",
                table: "Kvarovi",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Kvarovi_Strojevi_StrojId",
                table: "Kvarovi",
                column: "StrojId",
                principalTable: "Strojevi",
                principalColumn: "Id");
        }
    }
}

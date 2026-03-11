using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VanadoProjekt.Migrations
{
    /// <inheritdoc />
    public partial class CreateKvarovi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Strojevi",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Kvarovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StrojId = table.Column<int>(type: "integer", nullable: true),
                    Ime = table.Column<string>(type: "text", nullable: true),
                    Opis = table.Column<string>(type: "text", nullable: true),
                    VrijemePocetka = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VrijemeZavrsetka = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kvarovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kvarovi_Strojevi_StrojId",
                        column: x => x.StrojId,
                        principalTable: "Strojevi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kvarovi_StrojId",
                table: "Kvarovi",
                column: "StrojId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kvarovi");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Strojevi",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotaCrud.Migrations
{
    /// <inheritdoc />
    public partial class notas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTitulo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_sTitulo",
                table: "Notas",
                column: "sTitulo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");
        }
    }
}

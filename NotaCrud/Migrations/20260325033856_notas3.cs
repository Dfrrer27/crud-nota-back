using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotaCrud.Migrations
{
    /// <inheritdoc />
    public partial class notas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notas_sTitulo",
                table: "Notas");

            migrationBuilder.AlterColumn<string>(
                name: "sTitulo",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "sDescripcion",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sDescripcion",
                table: "Notas");

            migrationBuilder.AlterColumn<string>(
                name: "sTitulo",
                table: "Notas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_sTitulo",
                table: "Notas",
                column: "sTitulo",
                unique: true);
        }
    }
}

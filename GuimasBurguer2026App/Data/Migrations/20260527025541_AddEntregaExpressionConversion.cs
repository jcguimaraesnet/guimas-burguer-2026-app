using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguer2026App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEntregaExpressionConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EntregaExpressa",
                table: "Hamburguer",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EntregaExpressa",
                table: "Hamburguer",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuimasBurguer2026App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCargaMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "MarcaId", "Nome" },
                values: new object[,]
                {
                    { 1, "Sadia" },
                    { 2, "Seara" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marca",
                keyColumn: "MarcaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marca",
                keyColumn: "MarcaId",
                keyValue: 2);
        }
    }
}

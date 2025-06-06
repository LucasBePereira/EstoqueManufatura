using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueManufatura.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Componente", new[] { "PN", "Descricao" }, new object[] { "CP20Z3030", "Componente plastico Base" });
            migrationBuilder.InsertData("Componente", new[] { "PN", "Descricao" }, new object[] { "CP20Z4040", "Componente plastico Corpo" });
            migrationBuilder.InsertData("Componente", new[] { "PN", "Descricao" }, new object[] { "CP20Z5050", "Componente plastico Tampa" });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Componente");
        }
    }
}

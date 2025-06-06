using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueManufatura.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class ComponenteDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Projeto", new[] { "Plataforma", "ComponenteId" }, new object[] { "Chronos", 2 });
            migrationBuilder.InsertData("Projeto", new[] { "Plataforma", "ComponenteId" }, new object[] { "Pulse", 2 });
            migrationBuilder.InsertData("Projeto", new[] { "Plataforma", "ComponenteId" }, new object[] { "Mobi", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

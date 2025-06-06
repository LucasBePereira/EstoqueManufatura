using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueManufatura.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateComponenteProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComponenteId",
                table: "Projeto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ComponenteId",
                table: "Projeto",
                column: "ComponenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Componente_ComponenteId",
                table: "Projeto",
                column: "ComponenteId",
                principalTable: "Componente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Componente_ComponenteId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_ComponenteId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "ComponenteId",
                table: "Projeto");
        }
    }
}

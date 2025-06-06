using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueManufatura.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateComponenteEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteEstoque",
                columns: table => new
                {
                    ComponentesId = table.Column<int>(type: "int", nullable: false),
                    EstoquesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteEstoque", x => new { x.ComponentesId, x.EstoquesId });
                    table.ForeignKey(
                        name: "FK_ComponenteEstoque_Componente_ComponentesId",
                        column: x => x.ComponentesId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponenteEstoque_Estoque_EstoquesId",
                        column: x => x.EstoquesId,
                        principalTable: "Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteEstoque_EstoquesId",
                table: "ComponenteEstoque",
                column: "EstoquesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteEstoque");

            migrationBuilder.DropTable(
                name: "Estoque");
        }
    }
}

using EstoqueManufatua_API.Response;
using EstoqueManufatura.Shared.Data.BD;
using EstoqueManufatura_Console;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueManufatua_API.EndPoints
{
    public static class ProjetoExtension
    {
        public static void AddEndpointsProjeto(this
           WebApplication app)
        {
            var groupBuilder = app.MapGroup("Projeto")
                .RequireAuthorization()
                .WithTags("Porjetos");
            groupBuilder.MapGet("", ([FromServices] DAL<Projeto> dal) =>
            {
                var projlist = dal.Read();
                var projetoResponseList = EntityListToResponseList(projlist);
                return Results.Ok(projetoResponseList);
            }
            );

            groupBuilder.MapGet("/{id}", (int id, [FromServices] DAL<Projeto> dal) =>
            {
                var projList = dal.ReadBy(c => c.Id == id);
                if (projList == null) return Results.NotFound("Projeto não encontrado.");
                return Results.Ok(EntityToResponse(projList));
            }
            );

            groupBuilder.MapPost("", ([FromServices] DAL<Projeto> dal, [FromBody] Projeto c) =>
            {
                dal.create(c);
                return Results.Created();
            }
            );

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Projeto> dal, int id) =>
            {
                var comp = dal.ReadBy(c => c.Id == id);
                if (comp == null)
                {
                    return Results.NotFound("Projeto não encontrado.");
                }
                dal.Delete(comp);
                return Results.NoContent();
            }
            );

            groupBuilder.MapPut("", ([FromServices] DAL<Projeto> dal, [FromBody] Projeto c) =>
            {
                var compToEdit = dal.ReadBy(e => e.Id == c.Id);
                if (compToEdit is null) return Results.NotFound();
                compToEdit.Plataforma = c.Plataforma;
                dal.Update(compToEdit);
                return Results.Created();

            });
        }

        private static ICollection<ProjetoResponse> EntityListToResponseList(IEnumerable<Projeto> entities)
        {
            return entities.Select(a => EntityToResponse(a)).ToList();
        }

        private static ProjetoResponse EntityToResponse(Projeto entity)
        {
            return new ProjetoResponse(
                entity.Id,
                entity.Plataforma,
                entity.Componente?.Id ?? 0,
                entity.Componente?.PN ?? "Componente não encontrado");
        }

    }
}

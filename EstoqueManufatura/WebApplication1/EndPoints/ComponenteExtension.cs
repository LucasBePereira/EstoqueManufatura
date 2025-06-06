using EstoqueManufatua_API.Requests;
using EstoqueManufatua_API.Response;
using EstoqueManufatura.Shared.Data.BD;
using EstoqueManufatura_Console;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueManufatua_API.EndPoints
{
    public static class ComponenteExtension
    {
        public static void AddEndpointsComponente(this
           WebApplication app)
        {

            app.MapGet("/Componente", ([FromServices] DAL<Componente> dal) =>
            {
                var componentes = dal.Read();
                if (componentes == null) return Results.NotFound();
                var ComponenteResponseList = EntityListToResponseList(componentes);
                return Results.Ok(ComponenteResponseList);
            }
            );

            app.MapPost("/Componente", ([FromServices] DAL<Componente> dal, [FromBody] ComponenteRequest c) =>
            {
                dal.create(new Componente(c.PN, c.Descricao));
                return Results.Created();
            }
            );

            app.MapDelete("/Componente/{id}", ([FromServices] DAL<Componente> dal, int id) =>
            {
                var comp = dal.ReadBy(c => c.Id == id);
                if (comp == null)
                {
                    return Results.NotFound("Componente não encontrado.");
                }
                dal.Delete(comp);
                return Results.NoContent();
            }
            );

            app.MapPut("/Componente", ([FromServices] DAL<Componente> dal, [FromBody] ComponenteEditRequest c) =>
            {
                var compToEdit = dal.ReadBy(e => e.Id == c.Id);
                if (compToEdit is null) return Results.NotFound();
                compToEdit.PN = c.PN;
                compToEdit.Descricao = c.Descricao;
                dal.Update(compToEdit);
                return Results.Created();

            });
        }

        private static ICollection<ComponenteResponse> EntityListToResponseList(IEnumerable<Componente> entities)
        {
            return entities.Select(a => EntityToResponse(a)).ToList();
        }

        private static ComponenteResponse EntityToResponse(Componente entity)
        {
            return new ComponenteResponse(entity.Id, entity.PN, entity.Descricao);
        }
    }
}

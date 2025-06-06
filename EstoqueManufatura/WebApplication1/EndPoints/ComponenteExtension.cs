using EstoqueManufatua_API.Requests;
using EstoqueManufatua_API.Response;
using EstoqueManufatura.Sahred.Models;
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
            var groupBuilder = app.MapGroup("Componente")
                .RequireAuthorization()
                .WithTags("Componentes");

            groupBuilder.MapGet("", ([FromServices] DAL<Componente> dal) =>
            {
                var componentes = dal.Read();
                if (componentes == null) return Results.NotFound();
                var ComponenteResponseList = EntityListToResponseList(componentes);
                return Results.Ok(ComponenteResponseList);
            }
            );

            groupBuilder.MapGet("/{id}", (int id,[FromServices] DAL<Componente> dal) =>
            {
                var comp = dal.ReadBy(c => c.Id == id);
                if (comp == null) return Results.NotFound("Componente não encontrado.");
                return Results.Ok(EntityToResponse(comp));
            }
            );

            groupBuilder.MapPost("", ([FromServices] DAL<Componente> dal,[FromServices]DAL<Estoque> estoqdal, [FromBody] ComponenteRequest c) =>
            {
                dal.create(
                    new Componente(c.PN, c.Descricao)
                    { Estoques = c.Estoques is not null?
                        EstoqueRequestConvert(c.Estoques,estoqdal): 
                        new List<Estoque>()
                    }
                );
                return Results.Created();
            }
            );

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Componente> dal, int id) =>
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

            groupBuilder.MapPut("", ([FromServices] DAL<Componente> dal, [FromBody] ComponenteEditRequest c) =>
            {
                var compToEdit = dal.ReadBy(e => e.Id == c.Id);
                if (compToEdit is null) return Results.NotFound();
                compToEdit.PN = c.PN;
                compToEdit.Descricao = c.Descricao;
                dal.Update(compToEdit);
                return Results.Created();

            });
        }

        private static List<Estoque> EstoqueRequestConvert(ICollection<EstoqueRequest> EstoqList,DAL<Estoque>estodal)
        {
            var estoqueList = new List<Estoque>();
            foreach (var item in EstoqList)
            {
                var estoq = RequestToEntity(item);
                var estoqBusca = estodal.ReadBy(d => d.Nome.ToUpper().Equals(estoq.Nome.ToUpper()));
                if (estoqBusca is not null) estoqueList.Add(estoqBusca);
                else estoqueList.Add(estoq);

            }
            
            return estoqueList;
        }

        private static Estoque RequestToEntity(EstoqueRequest d)
        {
            return new Estoque() { Nome = d.Name};
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

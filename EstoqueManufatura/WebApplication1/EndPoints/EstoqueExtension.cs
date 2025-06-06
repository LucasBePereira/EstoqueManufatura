using EstoqueManufatua_API.Requests;
using EstoqueManufatua_API.Response;
using EstoqueManufatura.Sahred.Models;
using EstoqueManufatura.Shared.Data.BD;
using EstoqueManufatura_Console;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueManufatua_API.EndPoints
{
    public static class EstoqueExtension
    {
        public static void AddEndpointsEstoque(this
        WebApplication app)
        {

            app.MapGet("/Estqoue", ([FromServices] DAL<Estoque> dal) =>
            {
                var estoqList = dal.Read();
                if (estoqList == null) return Results.NotFound();
                var ComponenteResponseList = EntityListToResponseList(estoqList);
                return Results.Ok(ComponenteResponseList);
            }
            );

            app.MapPost("/Estqoue", ([FromServices] DAL<Estoque> dal, [FromBody] EstoqueRequest estoq) =>
            {
                dal.create(RequestToEntity(estoq));
                return Results.Created();
            });
               

            app.MapDelete("/Estqoue/{id}", ([FromServices] DAL<Estoque> dal, int id) =>
            {
                var estoq = dal.ReadBy(c => c.Id == id);
                if (estoq == null)
                {
                    return Results.NotFound("Estoque não encontrado.");
                }
                dal.Delete(estoq);
                return Results.NoContent();
            }
            );


        }
        private static Estoque RequestToEntity(EstoqueRequest estoq)
        {
            return new Estoque() { Nome = estoq.Name };
        }

        private static List<EstoqueResponse> EntityListToResponseList(IEnumerable<Estoque> estoqList)
        {
            return estoqList.Select(e => EntityToResponse(e)).ToList();
        }
        
        private static EstoqueResponse EntityToResponse(Estoque e)
        {
            return new EstoqueResponse(e.Id, e.Nome);
        }
    }
}

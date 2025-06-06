using EstoqueManufatura.Sahred.Models;

namespace EstoqueManufatua_API.Requests
{
    public record ComponenteRequest(string PN, string Descricao, ICollection<EstoqueRequest> Estoques = null);
    
}

using System.Globalization;

namespace EstoqueManufatua_API.Requests
{
    public record ComponenteEditRequest(string PN, string Descricao, int Id);
    
}

using EstoqueManufatura_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura.Sahred.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Componente> Componentes { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}- Nome: {Nome},";
        }
    }
}


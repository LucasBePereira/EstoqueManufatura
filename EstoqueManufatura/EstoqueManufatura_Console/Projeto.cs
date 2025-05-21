using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura_Console
{
    internal class Projeto
    {
        public string Plataforma { get; set; } // Project name

        public string Montadora { get; set; } // Project description

        public Projeto(string plataforma, string montadora)
        {
            Plataforma = plataforma;
            Montadora = montadora;
        }

        public override string ToString()
        {
            return $"Plataformas do componente: {Plataforma} \n";
        }
    }
}

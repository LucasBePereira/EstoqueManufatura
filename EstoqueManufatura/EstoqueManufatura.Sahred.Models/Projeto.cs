using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura_Console
{
    public class Projeto
    {
        public string Plataforma { get; set; } // Project name

        //public string Montadora { get; set; } // Project description
        public virtual Componente? Componente { get; set; } // Component associated with the project
        public int Id { get; set; }

        public Projeto(string plataforma)
        {
            Plataforma = plataforma;
            //Montadora = montadora;
            
        }

        public override string ToString()
        {
            return $"Plataformas do componente: {Plataforma} \n";
        }
    }
}

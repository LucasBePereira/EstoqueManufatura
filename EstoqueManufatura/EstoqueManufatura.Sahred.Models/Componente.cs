using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura_Console
{
    public class Componente
    {
        public Componente(string pn, string descricao)
        {
            PN = pn;
            Descricao = descricao;
        }

        public string PN { get; set; } // Part Number
                                        
        public string Descricao { get; set; } // Description

        private List<Projeto> plataformas = new();
        public override string ToString()
        {
            return $"PN: {PN}";
        }

        public void AdicionarProjeto(Projeto p)
        {
            plataformas.Add(p);
        }

        public void ShowPlataformas()
        {
            Console.WriteLine($"Plataformas do componente {PN}");
            if (plataformas.Count == 0)
            {
                Console.WriteLine("Nenhuma plataforma registrada.");
                return;
            }
            else
            {
                foreach (Projeto p in plataformas)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}

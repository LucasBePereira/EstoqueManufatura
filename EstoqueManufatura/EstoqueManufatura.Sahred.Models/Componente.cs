using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura_Console
{
    public class Componente
    {
        public Componente(string PN, string Descricao)
        {
            this.PN = PN;
            this.Descricao = Descricao;
        }

        public string PN { get; set; } // Part Number

        public string Descricao { get; set; } // Description

        public int Id { get; set; } // ID   


        private List<Projeto> plataformas = new();
        public override string ToString()
        {
            return $@"{Id}: {PN}";
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

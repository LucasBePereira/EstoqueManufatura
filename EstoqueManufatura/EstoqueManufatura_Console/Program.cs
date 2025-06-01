using EstoqueManufatura_Console;
using EstoqueManufatura.Shared.Data.BD;
using Microsoft.Data.SqlClient;

internal class Program
{
    public static Dictionary<string, Componente> ComponenteList = new();
    private static void Main(string[] args)
    {

        var componenteDAL = new DAL<Componente>();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Você chegou no Estoque Manufatura\n");
            Console.WriteLine("Digite 1 para registrar um Componente");
            Console.WriteLine("Digite 2 para registrar a plataforma de um componente");
            Console.WriteLine("Digite 3 para mostrar todos os componentes");
            Console.WriteLine("Digite 4 para mostrar as plataformas de um componente");
            Console.WriteLine("Digite -1 para sair\n");
            Console.WriteLine("Informe sua opção:");
            int option = int.Parse(Console.ReadLine());
            
            switch (option)
            {

                case -1:
                    exit = true;
                    break;

                case 1:
                    RegistrodeComponente();
                    break;
                case 2:
                    //RegistrodePlataforma();
                    break;
                case 3:
                    Componenteget();
                    break;
                case 4:
                    //Plataformaget();
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }

        void RegistrodeComponente()
        {
            Console.Clear();
            Console.WriteLine("Registro de componente\n");
            Console.WriteLine("Digite o PN [LLNNLNNNN] do componente a ser cadastrado:\n");
            string pn = Console.ReadLine();
            Console.WriteLine("Digite a descrição do componente:\n");
            string descricao = Console.ReadLine();

            Componente c = new(pn, descricao);
            componenteDAL.create(c);

            Console.WriteLine($"Componente {pn} registrado com sucesso!\n");
            Console.ReadKey();
        }

        void Componenteget()
        {
            Console.Clear();
            Console.WriteLine("Lista dos componentes\n");
            foreach (var item in componenteDAL.Read())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        //void Plataformaget()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Exibir detalhes do componente\n");
        //    Console.WriteLine("Digite o PN do componente cuja Plataformas deseja  consultar:\n");
        //    string pn = Console.ReadLine();
        //    if (ComponenteList.ContainsKey(pn))
        //    {
        //        Componente p = ComponenteList[pn];
        //        p.ShowPlataformas();
        //        Console.WriteLine("\n");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Componente {pn} não encontrado.\n");
        //    }
        //}

        //void RegistrodePlataforma()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Registro de Plataformas\n");
        //    Console.WriteLine("Digite o PN do componente cuja Plataforma será registrada:\n");
        //    string pn = Console.ReadLine();
        //    if (ComponenteList.ContainsKey(pn))
        //    {
        //        Console.WriteLine($"Digite o nome da plataforma a ser registrada para {pn}:\n");
        //        string plataforma = Console.ReadLine();
        //        Console.WriteLine("Digite a Motadora da plataforma:\n");
        //        string montadora = Console.ReadLine();
        //        Componente p = ComponenteList[pn];
        //        p.AdicionarProjeto(new Projeto(plataforma, montadora));

        //        Console.WriteLine($"Plataforma {plataforma} registrada com sucesso!\n");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Componente {pn} não encontrado.\n");
        //    }
        //}
    }
}
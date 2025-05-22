using EstoqueManufatura_Console;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura.Shared.Data.BD
{
    public class ComponenteDAL
    {
        public void Create(Componente componente)
        {
            using var connection = new EstoqueManufaturaContext().Connect();
            connection.Open();

            string sql = "INSERT INTO Componente (PN, Descricao) VALUES (@PN, @Descricao)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@PN", componente.PN);
            cmd.Parameters.AddWithValue("@Descricao", componente.Descricao);

            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno} \n");
        }

        public IEnumerable<Componente> Reach()
        {
            var list = new List<Componente>();

            using var connection = new EstoqueManufaturaContext().Connect();
            connection.Open();

            string sql = "SELECT * FROM Componente";
            SqlCommand cmd = new SqlCommand(sql, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    string ComponentPN = Convert.ToString(reader["PN"]);
                    string ComponentDescriao = Convert.ToString(reader["Descricao"]);
                    Componente componente = new Componente(ComponentPN, ComponentDescriao);
                    list.Add(componente);
                }

                return list;

            }
        }

        public void Update(Componente componente, int id)
        {
            using var connection = new EstoqueManufaturaContext().Connect();
            connection.Open();
            string sql = $"UPDATE Componente SET PN = @PN, Descricao = @Descricao WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@PN", componente.PN);
            cmd.Parameters.AddWithValue("@Descricao", componente.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno} \n");
        }

        public void Delete(int id)
        {
            using var connection = new EstoqueManufaturaContext().Connect();
            connection.Open();

            string sql = $"DELETE FROM Componente WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);
            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno} \n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueManufatura_Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EstoqueManufatura.Shared.Data.BD
{
    public class Context : DbContext
    {

        public DbSet<Componente> Componente { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EstoqueManufatura_BD;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

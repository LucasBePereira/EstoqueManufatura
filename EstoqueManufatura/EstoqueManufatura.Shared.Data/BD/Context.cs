using EstoqueManufatura.Sahred.Models;
using EstoqueManufatura_Console;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueManufatura.Shared.Data.BD
{
    public class Context : DbContext
    {
        public DbSet<Componente> Componente { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EstoqueManufatura_BD_V1;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).
            UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Componente>()
                .HasMany(c => c.Estoques)
                .WithMany(p => p.Componentes);
   
        }
    }
}

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
        private readonly Context context1;

        public ComponenteDAL()
        {
            context1 = new Context();
        }

        public void create(Componente cpn)
        {
            
            context1.Set<Componente>().Add(cpn);
            context1.SaveChanges();
        }
        public IEnumerable<Componente> Read()
        {
            
            return context1.Componente.ToList();
        }

        public void update(Componente cpn)
        {
            
            context1.Componente.Update(cpn);
            context1.SaveChanges();
        }

        public void delete(Componente cpn)
        {
            
            context1.Componente.Remove(cpn);
            context1.SaveChanges();
        }
    }
}

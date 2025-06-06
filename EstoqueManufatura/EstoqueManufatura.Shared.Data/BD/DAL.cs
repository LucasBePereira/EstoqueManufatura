using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EstoqueManufatura;
using EstoqueManufatura.Shared.Data;

namespace EstoqueManufatura.Shared.Data.BD
{
    public class DAL<T> where T : class
    {
        private readonly Context context1;

        public DAL() 
        {
            context1 = new Context();
        }
        public void create(T value)
        {
            context1.Set<T>().Add(value);
            context1.SaveChanges();
        }
        public IEnumerable<T> Read()
        { 
            return context1.Set<T>().ToList();
        }

        public void Update(T value)
        {
            context1.Set<T>().Update(value);
            context1.SaveChanges();
        }

        public void Delete(T value)
        {
            context1.Set<T>().Remove(value);
            context1.SaveChanges();
        }

        public T? ReadBy(Func<T, bool> predicate)
        {
            return context1.Set<T>().FirstOrDefault(predicate);
    }

}
}

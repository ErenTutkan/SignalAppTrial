using SignalAppTrial.DataAccess.Abstract;
using SignalAppTrial.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        Context c = new Context();
        public void Add(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }
        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }
        public T GetById(string id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return c.Set<T>().ToList();
        }
        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}

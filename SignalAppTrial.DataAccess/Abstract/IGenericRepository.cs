using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetListAll();
        void Delete(T t);
        void Add(T t);
        void Update(T t);
        T GetById(string id);
    }
}

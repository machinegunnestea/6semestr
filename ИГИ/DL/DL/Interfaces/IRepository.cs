using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}

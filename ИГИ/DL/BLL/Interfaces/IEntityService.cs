using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВLL.Interfaces
{
    public interface IEntityService<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        IEnumerable<T> Get();
    }
}

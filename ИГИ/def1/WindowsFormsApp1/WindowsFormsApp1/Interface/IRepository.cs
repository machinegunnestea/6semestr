using System.Collections.Generic;

namespace WindowsFormsApp1.Interface
{
    public interface IRepository<T> where T:class
    {
        bool Create(T item);
        bool Delete(string item);
        void FindByHeight(int height);
        T FindByWeight(int weight);
        List<T> GetAll();
    }
}
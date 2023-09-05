using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Interface;

namespace WindowsFormsApp1.Repositories
{
    public static class Search
    {
        public static Aligator FindByWeight(IRepository<Aligator> repository, int weight)
        {
            return repository.FindByWeight(weight);
        }
    }
}

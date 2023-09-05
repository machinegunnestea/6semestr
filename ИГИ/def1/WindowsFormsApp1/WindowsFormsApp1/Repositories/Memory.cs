using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Interface;

namespace WindowsFormsApp1.Repositories
{
    class Memory : IAligatorRepository
    {
        private List<Aligator> aligators = new List<Aligator>();
        public Memory()
        {
            aligators.Add(new Aligator("Илон", 50, 75));
            aligators.Add(new Aligator("Комета", 80, 75));
            aligators.Add(new Aligator("Вижен", 100, 60));
        }
        public bool Create(Aligator item)
        {
            try
            {
                aligators.Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string item)
        {
            throw new NotImplementedException();
        }

        public void FindByHeight(int weight)
        {
            throw new NotImplementedException();
        }

        public Aligator FindByWeight(int weight)
        {
            return aligators.FirstOrDefault(x => x.Weight == weight);
        }

        public List<Aligator> GetAll()
        {
            return aligators;
        }
    }
}

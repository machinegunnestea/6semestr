using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class CarType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        ICollection<Car> cars { get; set;}
    }
}

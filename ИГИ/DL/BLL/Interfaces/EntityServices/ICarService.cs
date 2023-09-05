using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;
using ВLL.Interfaces;

namespace BLL.Interfaces.EntityServices
{
    public interface ICarService : IEntityService<CarDTO>
    {
        IEnumerable<CarDTO> Find(int cost);
    }
}

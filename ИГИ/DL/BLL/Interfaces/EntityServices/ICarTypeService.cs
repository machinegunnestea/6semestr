using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;

namespace ВLL.Interfaces.EntityServices
{
    public interface ICarTypeService:IEntityService<CarTypeDTO>
    {
        IEnumerable<CarTypeDTO> Find(string typeName);
    }
}

using System.Collections.Generic;
using ВLL.DTO;

namespace ВLL.Interfaces.EntityServices
{
    public interface IMovieTypeService:IEntityService<MovieTypeDTO>
    {
        IEnumerable<MovieTypeDTO> Find(string typeName);
    }
}

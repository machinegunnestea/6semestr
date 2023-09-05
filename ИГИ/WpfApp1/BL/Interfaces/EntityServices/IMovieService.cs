using BLL.DTO;
using System.Collections.Generic;
using ВLL.Interfaces;

namespace BLL.Interfaces.EntityServices
{
    public interface IMovieService : IEntityService<MovieDTO>
    {
        IEnumerable<MovieDTO> Find(int cost);
    }
}

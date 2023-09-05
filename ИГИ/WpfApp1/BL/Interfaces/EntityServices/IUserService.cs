using System.Collections.Generic;
using ВLL.DTO;

namespace ВLL.Interfaces.EntityServices
{
    public interface IUserService:IEntityService<UserDTO>
    {
        IEnumerable<UserDTO> Find(string login);
    }
}

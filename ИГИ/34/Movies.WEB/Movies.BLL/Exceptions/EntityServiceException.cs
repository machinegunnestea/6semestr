using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.Exceptions
{
    public class EntityServiceException : Exception
    {
        public EntityServiceException(string message) : base(message)
        {
        }
    }
}

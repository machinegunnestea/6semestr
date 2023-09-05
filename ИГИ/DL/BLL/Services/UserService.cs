using AutoMapper;
using DL.Entities;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;
using ВLL.Interfaces.EntityServices;

namespace ВLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Create(UserDTO item)
        {
            _unitOfWork.User.Create(mapper.Map<User>(item));
        }

        public void Delete(int id)
        {
            _unitOfWork.User.Delete(id);
        }

        public IEnumerable<UserDTO> Find(string login)
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_unitOfWork.User.Find(name => name.Login == login));
        }

        public IEnumerable<UserDTO> Get()
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_unitOfWork.User.Get());
        }
    }
}

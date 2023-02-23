using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Models.DTO;

namespace webAPI.BLL.Interface.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
        Task<Result> Create(UserDTO userDTO);
        Task<Result> Update(UserDTO userDTO, int id);
        Task<Result> Delete(int id);
    }
}

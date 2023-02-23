using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Interface.Repository;
using webAPI.BLL.Interface.Services;
using webAPI.BLL.Models.DTO;

namespace webAPI.BLL.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Create(UserDTO userDTO)
        {
            return await _userRepository.Create(userDTO);
        }

        public async Task<Result> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserDTO GetById(int id)
        {
           return _userRepository.GetById(id);
        }

        public async Task<Result> Update(UserDTO userDTO, int id)
        {
            return await _userRepository.Update(userDTO, id);
        }
    }
}

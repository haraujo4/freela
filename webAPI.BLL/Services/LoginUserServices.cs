using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Interface.Services;
using webAPI.BLL.Models.DTO;
using webAPI.BLL.Models.Request;

namespace webAPI.BLL.Services
{
    public class LoginUserServices:ILoginUserServices
    {
        private readonly ILoginUserServices _services;

        public LoginUserServices(ILoginUserServices services)
        {
            _services = services;
        }

        public UserDTO login(LoginRequest login)
        {
            return _services.login(login);
        }
    }
}

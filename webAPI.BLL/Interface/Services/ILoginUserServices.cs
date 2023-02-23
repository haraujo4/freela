using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Models.DTO;
using webAPI.BLL.Models.Request;

namespace webAPI.BLL.Interface.Services
{
    public interface ILoginUserServices
    {
        UserDTO login(LoginRequest login);
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Interface.Repository;
using webAPI.BLL.Models.DTO;
using webAPI.BLL.Models.Request;

namespace webAPI.DAL.Repository
{
    public class LoginUserRepository : ILoginUserRepository
    {
        private readonly IDbConnection _connection;
        public LoginUserRepository(IDbConnection connection)
        {           
            _connection = connection;            
        }
        public UserDTO login(LoginRequest login)
        {
            //PRECISA RECEBER A SENHA E CRIPTOGRAFAR ANTES DE PASSAR PARA O CAMPO PASSWORD NO ENTANDO DO JEITO QUE ESTÁ
            //TAMBEM FUNCIONA
            var query = $@"SELECT ID UserId, NOME UserName, EMAIL UserEmail, ROLE Role, STATUS Status FROM User
                        WHERE EMAIL = '{login.Email}' AND Password = '{login.Password}'";
            try
            {
                var result = _connection.Query<UserDTO>(query).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                return new UserDTO();
            }
        }
    }
}

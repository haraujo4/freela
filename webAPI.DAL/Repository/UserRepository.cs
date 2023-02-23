using Dapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Interface.Repository;
using webAPI.BLL.Models.DTO;

namespace webAPI.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public async Task<Result> Create(UserDTO userDTO)
        {
            //PRECISA RECEBER A SENHA E CRIPTOGRAFAR ANTES DE PASSAR PARA O CAMPO PASSWORD NO ENTANDO DO JEITO QUE ESTÁ
            //TAMBEM FUNCIONA
            var query = $@"INSERT INTO USER(NOME, EMAIL, PASSWORD,  ROLE, STATUS)
                        VALUES('{userDTO.UserName}','{userDTO.UserEmail}','{userDTO.Password}','{userDTO.Role}','A')";
            try
            {
                await _connection.ExecuteAsync(query);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.ToString());
            }
        }

        public async Task<Result> Delete(int id)
        {
            var query = $@"DELETE FROM USER WHERE ID = {id}";
            try
            {
                await _connection.ExecuteAsync(query);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.ToString());
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var query = $@"SELECT ID UserId, NOME UserName, EMAIL UserEmail, ROLE Role, STATUS Status FROM User ";
            try
            {
                var result = _connection.Query<UserDTO>(query);
                return result;
            }
            catch(Exception ex)
            {
                return new List<UserDTO>();
            }
        }

        public UserDTO GetById(int id)
        {
            var query = $@"SELECT ID UserId, NOME UserName, EMAIL UserEmail, ROLE Role, STATUS Status FROM User
                        WHERE ID = {id}";
            try
            {
                var result = _connection.Query<UserDTO>(query).FirstOrDefault();
                return result;
            }
            catch(Exception ex)
            {
                return new UserDTO();
            }
        }

        public async Task<Result> Update(UserDTO userDTO, int id)
        {
            var query = $@"UPDATE USER SET
                        NAME = '{userDTO.UserName}',
                        EMAIL = '{userDTO.UserEmail}',
                        ROLE = '{userDTO.Role}',
                        STATUS = '{userDTO.Status}'
                        WHERE ID = '{id}'";
            try
            {
                await _connection.ExecuteAsync(query);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.ToString());
            }
        }
    }
}

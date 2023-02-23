using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using webAPI.BLL.Models.DTO;

namespace webAPI.BLL.Helpers
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _config;
        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(UserDTO usuario)
        {
            Claim[] claims = new Claim[] {
                new Claim("username",usuario.UserName),
                new Claim("role",usuario.Role),
                new Claim("status",usuario.Status),
            };
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Security:CypherKey"]));
            var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(8)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}

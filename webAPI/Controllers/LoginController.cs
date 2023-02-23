using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.BLL.Helpers;
using webAPI.BLL.Interface.Services;
using webAPI.BLL.Models.Request;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginUserServices _loginUserServices;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public LoginController(ILoginUserServices loginUserServices, JwtTokenGenerator jwt)
        {
            _loginUserServices = loginUserServices;
            _jwtTokenGenerator = jwt;
        }

        [HttpPost]
        public ActionResult Login(LoginRequest login)
        {
            var user = _loginUserServices.login(login);
            if (user == null)
            {
                
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
                {
                var token = _jwtTokenGenerator.CreateToken(user);
                Response.Cookies.Append("token", token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                });
                return Ok(new { token });
            }
            
        }
    }
}

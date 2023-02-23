using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.BLL.Interface.Services;
using webAPI.BLL.Models.DTO;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public UserDTO GetById(int id)
        {
            return _services.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            if (userDTO != null)
            {
                var user = await _services.Create(userDTO);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }           
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update([FromBody]UserDTO userDTO, int id)
        {
            if (userDTO != null)
            {
                var user = await _services.Update(userDTO, id);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
                
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userInfo = _services.GetById(id);
            if(userInfo != null)
            {
                var result = await _services.Delete(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}

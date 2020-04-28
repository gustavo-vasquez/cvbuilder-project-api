using CVBuilder.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;
using CVBuilder.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilder.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest("Datos no válidos. Vuelva a intentarlo.");

            _userService.Create(Mapping.Mapper.Map<RegisterModel,UserDTO>(model));

            UserDTO userInfo;
            
            if(_userService.IsAuthenticated(model.Email, model.Password, out userInfo))
            {
                return Ok(userInfo);
            }
            else
                return BadRequest("No se ha podido iniciar sesión automáticamente.");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest("Datos no válidos. Vuelva a intentarlo.");

            UserDTO userInfo;
            
            if(_userService.IsAuthenticated(model.Email, model.Password, out userInfo))
            {
                return Ok(userInfo);
            }
            else
                return BadRequest("Error al iniciar sesión.");
        }
    }
}
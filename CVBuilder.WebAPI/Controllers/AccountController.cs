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
        [HttpPost("[action]")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            _userService.Create(Mapping.Mapper.Map<RegisterModel,UserDTO>(model));

            UserDTO userInfo;
            
            if(_userService.IsAuthenticated(model.Email, model.Password, out userInfo))
                return Ok(userInfo);
            else
                return BadRequest("No se ha podido iniciar sesión automáticamente.");
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            UserDTO userInfo;
            
            if(_userService.IsAuthenticated(model.Email, model.Password, out userInfo))
                return Ok(userInfo);
            else
                return BadRequest("Error al iniciar sesión. Vuelva a intentarlo.");
        }

        [HttpGet("values")]
        public IActionResult GetValues()
        {
            return Ok(new { nombre = "cosme", apellido = "fulanito" });
        }

        [AllowAnonymous]
        [HttpGet("valuess")]
        public IActionResult GetValuess()
        {
            return Ok(new { nombre = "cosme", apellido = "fulanito" });
        }


        # region - HELPERS -

        # endregion
    }
}
using System;
using CVBuilder.Automapper;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;
using CVBuilder.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            try
            {
                _userService.Create(Mapping.Mapper.Map<RegisterModel,RegisterDTO>(model));
                return Login(new LoginModel() { Email = model.Email, Password = model.Password });
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException)
                    return BadRequest(new { Message = ex.Message });
                    
                return StatusCode(500, new { Message = ex.Message });
            }
            
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            UserDTO userInfo;
            
            if(_userService.IsAuthenticated(model.Email, model.Password, out userInfo))
                return Ok(userInfo);
            else
                return BadRequest(new { Message = "Email y/o contraseña incorrecta."});
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult ExchangeToken([FromBody]ExchangeTokenModel model)
        {
            try
            {
                ExchangeTokenDTO newTokens = _userService.ExchangeToken(model.Token, model.RefreshToken);
                return Ok(newTokens);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult ValidToken(string token)
        {
            try
            {
                return Ok(_userService.CurrentTokenIsValid(token));
            }
            catch(Exception ex)
            {
                if(ex is SecurityTokenExpiredException)
                    return Ok(false);

                return BadRequest(ex.Message);
            }
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
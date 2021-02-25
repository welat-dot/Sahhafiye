using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SahhafiyeBusiness.Abstract;
using SahhafiyeEntities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahhafiyeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [Route("register"),HttpPost]
        public IActionResult UserRegister(ForRegisterDto registerDto)
        {
            return Ok(authService.UserRegister(registerDto));
        }
        [Route("login"), HttpPost]
        public IActionResult UserLogin(ForLoginDto loginDto)
        {            
            return Ok(authService.UserLogin(loginDto));
        }
    }
}

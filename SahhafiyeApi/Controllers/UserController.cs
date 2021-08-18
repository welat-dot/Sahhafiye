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
    public class UserController : ControllerBase
    {
        private IUserBusiness userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }
        [Route("update"),HttpPost]
        public IActionResult update(ForRegisterDto registerDto)
        {
            return Ok(userBusiness.update(registerDto));
        }
    }
}

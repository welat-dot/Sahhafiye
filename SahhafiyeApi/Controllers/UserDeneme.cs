using Microsoft.AspNetCore.Mvc;
using SahafiyeDataAccess.Abstract;
using SahhafiyeEntities.Dto;
using SahhafiyeEntities.ProductEntity;
using SahhafiyeEntities.UsersEntity;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SahhafiyeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserDeneme : ControllerBase
    {
        private IUserManager userManager;
        public UserDeneme( IUserManager userManager)
        {
           
            this.userManager = userManager;
        }
        //[Route("add"),HttpPost]
        //public async Task<IActionResult> addAsync (ForRegisterDto users )
        //{
            
        //    Product product = new Product();
        //    return Ok( await userManager.AsyncSelectByFilter("user",x=>x.Id==x.userdeatil.Id));
        //}
    }
}

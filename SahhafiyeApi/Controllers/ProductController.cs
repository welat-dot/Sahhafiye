using Microsoft.AspNetCore.Mvc;
using SahhafiyeApi.Result;
using SahhafiyeBusiness.Abstract;
using SahhafiyeEntities.ProductEntity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahhafiyeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [Route("productGetAll"),HttpGet]
        public async Task<IActionResult> ProductGetAll()
        {
            Results<List<Product>> results = new Results<List<Product>>();
            IQueryable<Product> response =await productService.GetAll();
        //  var t=await productService.
            results.data = response.ToList();

            return Ok(results);
        }
    }
}

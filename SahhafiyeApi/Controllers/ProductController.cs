using Microsoft.AspNetCore.Mvc;
using SahhafiyeApi.Result;
using SahhafiyeBusiness.Abstract;
using SahhafiyeEntities.ProductEntity;
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
            Results results = new Results();
            IQueryable<Product> response =await productService.GetAll();
            results.data = response.ToList();

            return Ok(results);
        }
    }
}

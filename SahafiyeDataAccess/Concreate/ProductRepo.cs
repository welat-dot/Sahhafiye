using SahafiyeDataAccess.Abstract;
using SahhafiyeEntities.ProductEntity;
using System.Linq;
using System.Threading.Tasks;

namespace SahafiyeDataAccess.Concreate
{
    public class ProductRepo:IProductRepo
    {
        private IProductManager productManager;
        public ProductRepo  (IProductManager productManager)
        {
           this.productManager = productManager;
        }

        public async Task<IQueryable<Product>> ProductGetAll()
        {
            string que = "SELECT *FROM product";
            return await  productManager.AsyncFunctions(que);
        }
        //public IQueryable<Product> ProductAdd(Product product)
        //{

        //}
        
    }
}

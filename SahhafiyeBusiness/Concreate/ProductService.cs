using SahafiyeDataAccess.Abstract;
using SahhafiyeBusiness.Abstract;
using SahhafiyeEntities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahhafiyeBusiness.Concreate
{
    public class ProductService : IProductService
    {
        private IProductRepo ProductRepo;
        public ProductService (IProductRepo ProductRepo)
        {
            this.ProductRepo = ProductRepo;
        }
        public async Task<IQueryable<Product>> GetAll()
        {
            return await ProductRepo.ProductGetir();
        }
    }
}

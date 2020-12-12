using SahhafiyeEntities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahafiyeDataAccess.Abstract
{
    public interface IProductRepo
    {
        Task<IQueryable<Product>> ProductGetir();
    }
}

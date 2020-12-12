using SahhafiyeEntities.ProductEntity;
using System.Linq;
using System.Threading.Tasks;

namespace SahhafiyeBusiness.Abstract
{
    public interface IProductService
    {
         Task<IQueryable<Product>> GetAll();
    }
}

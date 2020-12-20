using SahhafiyeEntities.ProductEntity;
using System.Linq;
using System.Threading.Tasks;

namespace SahafiyeDataAccess.Abstract
{
    public interface IProductRepo
    {
        Task<IQueryable<Product>> ProductGetAll();
        //Task<IQueryable<Product>> ProductAdd();
    }
}

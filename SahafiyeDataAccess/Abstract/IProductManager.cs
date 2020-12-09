using SahafiyeCore.DataAccess.Dapper;
using SahhafiyeEntities.ProductEntity;

namespace SahafiyeDataAccess.Abstract
{
    public interface IProductManager: IDapperRepository<Product>
    {

	}
}

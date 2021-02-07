using SahafiyeCore.DataAccess.Dapper;
using SahhafiyeEntities.UsersEntity;
using System.Linq;
using System.Threading.Tasks;

namespace SahafiyeDataAccess.Abstract
{
    public interface IUserManager:IDapperRepository<Users>
    {
      
    }
}

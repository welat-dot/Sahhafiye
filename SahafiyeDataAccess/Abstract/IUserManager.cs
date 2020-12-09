using SahafiyeCore.DataAccess.Dapper;
using SahhafiyeEntities.UsersEntity;

namespace SahafiyeDataAccess.Abstract
{
    public interface IUserManager: IDapperRepository<Users>
    {
    }
}

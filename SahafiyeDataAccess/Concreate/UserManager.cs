using SahafiyeCore.DataAccess.Dapper;
using SahafiyeDataAccess.Abstract;
using SahhafiyeEntities.UsersEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Concreate
{
    public class UserManager: BaseDapperRepository<Users>,IUserManager
    {
    }
}

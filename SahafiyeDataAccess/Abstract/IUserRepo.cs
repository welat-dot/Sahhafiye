using SahafiyeCore.Utilitis.Result.Abstract;
using SahhafiyeEntities.Dto;
using SahhafiyeEntities.UsersEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahafiyeDataAccess.Abstract
{
    public interface IUserRepo
    {
        Users GetUsers(List<string> filter);
        IQueryable<Users> GetAllUsers();
        bool AddUser(Users users);
        bool DeleteUser(int Id);
        bool UpdateUser(Users users);
        IDataResult<Users> UserExisits(ForLoginDto loginDto);
    }
}

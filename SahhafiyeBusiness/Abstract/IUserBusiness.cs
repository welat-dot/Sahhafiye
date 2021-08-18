using SahafiyeCore.Utilitis.Result.Abstract;
using SahhafiyeEntities.Dto;
using SahhafiyeEntities.UsersEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahhafiyeBusiness.Abstract
{
   public interface IUserBusiness
    {
        IResult Add(users users);
        void delete(int id);
        IDataResult<bool> update(ForRegisterDto registerDto);
        IDataResult<users> userExistsForRegister(string mail);
        IDataResult<users>  userExistsForLogin(string mail);

    }
}

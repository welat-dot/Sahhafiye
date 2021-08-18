using SahafiyeCore.Utilitis.Security.JWT;
using SahafiyeDataAccess.Abstract;
using SahhafiyeBusiness.Abstract;
using SahhafiyeEntities.Dto;
using SahhafiyeEntities.UsersEntity;
using SahafiyeCore.Utilitis.Security.Hashing;
using System;
using SahafiyeCore.Utilitis.Result.Abstract;
using SahafiyeCore.Entities.Concreate;
using SahafiyeCore.Utilitis.Result.Concreate;
using System.Collections.Generic;

namespace SahhafiyeBusiness.Concreate
{
    public class AuthService : IAuthService
    {
       
        private IUserBusiness userBusiness;
        private ITokenHelper tokenHelper;
        public AuthService (ITokenHelper tokenHelper, IUserBusiness userBusiness)
        {
            this.tokenHelper = tokenHelper;
            this.userBusiness = userBusiness;
        }

        public IDataResult<AccessToken> UserLogin(ForLoginDto loginDto)
        {
            IDataResult<users> result;
            result = userBusiness.userExistsForLogin(loginDto.EmailAdress);
            if (result.success)            {
                users user = result.Data;
                if (HashingHelper.VerifityPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                    UserInfo user1 = new UserInfo();
                    user1.Authority.Add("yetki");
                    user1.email = user.EmailAdress;
                    user1.Id = user.Id;
                    user1.Name = "ali";
                    user1.StoreId = 5;
                    return new SuccessDataResult<AccessToken>(tokenHelper.CreateToken(user1));
                }
                else
                    return new ErrorDataResult<AccessToken>(null, ResultMessage.ErrorPassword);
            }            
            return new ErrorDataResult<AccessToken>(null, ResultMessage.ErrorSystem);
        }
        public IResult  UserRegister(ForRegisterDto registerDto)
        {
            if (userBusiness.userExistsForRegister(registerDto.EmailAdress).success)
                return new ErrorResult();
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreateHash(registerDto.Password, out passwordHash, out passwordSalt);
            users users = new users();
            users.EmailAdress = registerDto.EmailAdress;
            users.TelNumber = "";
            users.PasswordHash = passwordHash;
            users.PasswordSalt = passwordSalt;
            users.RecordDate = DateTime.Now;
            users.UserName = "";
            users.UpdateDate = DateTime.Now;
            return userBusiness.Add(users);
        }
        public IDataResult<users> UserExists(string userMail)
        {
            try
            {
                users user = new users();
                //user = userRepo.GetUsers(new List<string>() { " Users.EmailAdress = '" + userMail + "' OR " +
                //                                              " Users.TelNumber   = '" + userMail + "'" });
                //if(user == null)
                //{
                //    return new SuccessDataResult<user>(null);
                //}
                return new SuccessDataResult<users>(user);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<users>(null);
            }
        }

    }
}

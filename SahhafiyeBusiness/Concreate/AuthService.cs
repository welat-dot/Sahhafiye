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
        private IUserRepo userRepo;
        private ITokenHelper tokenHelper;
        public AuthService (IUserRepo userRepo, ITokenHelper tokenHelper)
        {
            this.tokenHelper = tokenHelper;
            this.userRepo    = userRepo;
        }

        public IDataResult<AccessToken> UserLogin(ForLoginDto loginDto)
        {
            IDataResult<Users> result;
            result = UserExists(loginDto.EmailAdress);
            if(result.success&&result.Data !=null)
            {
                Users user = result.Data;
                bool a = HashingHelper.VerifityPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
                if (a)
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
            if (result.Data == null && result.success)
                return new ErrorDataResult<AccessToken>(null, ResultMessage.ErrorUser);
            return new ErrorDataResult<AccessToken>(null, ResultMessage.ErrorSystem);
        }
        public IResult  UserRegister(ForRegisterDto registerDto)
        {

            IDataResult<Users> result;
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreateHash(registerDto.Password, out passwordHash, out passwordSalt);
            Users users = new Users();
            if(registerDto.EmailAdress==null&&registerDto.TelNumber==null)
                return new ErrorResult(ResultMessage.ErrorUserMail);
            //check mail
            if (registerDto.EmailAdress != null)
            {
                result = UserExists(registerDto.EmailAdress);
                if (result.success && result.Data != null)
                    return new ErrorResult(ResultMessage.ErrorUserMail);
                if (!result.success)
                    return new ErrorResult(ResultMessage.ErrorSystem);
            }
            //check tel 
            if (registerDto.TelNumber != null)
            {
                result = UserExists(registerDto.TelNumber);
              
                if (result.success && result.Data != null)
                    return new ErrorResult(ResultMessage.ErrorUserTel);
                if (!result.success)
                    return new ErrorResult(ResultMessage.ErrorSystem);
                
            }
            try
            {
                if(registerDto.EmailAdress != null)
                    users.EmailAdress = registerDto.EmailAdress;
                if (registerDto.TelNumber != null)
                    users.TelNumber = registerDto.TelNumber;
                users.PasswordHash = passwordHash;
                users.PasswordSalt = passwordSalt;
                users.RecordTime   = DateTime.Now;
                users.TelNumber    = registerDto.TelNumber;
                users.UpdateTime   = DateTime.Now;
                userRepo.AddUser(users);
                return new SuccessResult(ResultMessage.RecordSuccess);
            }
            catch (Exception e)
            {

                return new ErrorResult(ResultMessage.ErrorSystem);
            }            
            
        }
        public IDataResult<Users> UserExists(string userMail)
        {
            try
            {
                Users user = new Users();
                user = userRepo.GetUsers(new List<string>() { " Users.EmailAdress = '" + userMail + "' OR " +
                                                              " Users.TelNumber   = '" + userMail + "'" });
                if(user == null)
                {
                    return new SuccessDataResult<Users>(null);
                }
                return new SuccessDataResult<Users>(user);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<Users>(null);
            }
        }

    }
}

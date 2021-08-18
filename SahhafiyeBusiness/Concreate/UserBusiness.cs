using SahafiyeCore.Utilitis.Result.Abstract;
using SahafiyeDataAccess.Abstract;
using SahhafiyeBusiness.Abstract;
using SahhafiyeEntities.UsersEntity;
using SahafiyeCore.Utilitis.Result.Concreate;
using System.Reflection;
using SahhafiyeEntities.Dto;
using SahafiyeCore.Utilitis.Security.Hashing;

namespace SahhafiyeBusiness.Concreate
{
    public class UserBusiness : IUserBusiness
    {
        private IUserManager userManager;
        public UserBusiness( IUserManager userManager)
        {
         
            this.userManager = userManager;
        }
        public IResult Add(users users)
        {
            if (userManager.insert(users, "users")>0)
                return new SuccessResult();
            return new ErrorResult();
           
        }

        public void delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<bool> update(ForRegisterDto registerDto)
        {
            users _user = new users();
            _user = userManager.SelectByFilter("users", "EmailAdress ='" + registerDto.EmailAdress + "'  or TelNumber ='" + registerDto.EmailAdress + "'");
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreateHash(registerDto.Password, out passwordHash, out passwordSalt);
            _user.PasswordHash = passwordHash;
            _user.PasswordSalt= passwordSalt;
            _user.UserName = "Admin";
            return new SuccessDataResult<bool>(userManager.update(_user, "users",_user.Id,x=>x.Id==_user.Id));

        }

        public IDataResult<users> userExistsForLogin(string mail)
        {          

            users _user = new users();
            _user = userManager.SelectByFilter("users", "EmailAdress ='"+ mail + "'  or TelNumber ='"+ mail + "'");
            if (_user == null)
                return new ErrorDataResult<users>(_user);
            return new SuccessDataResult<users>(_user);
        }

        public IDataResult<users> userExistsForRegister(string mail)
        {
            //"EmailAdress = '" + mail + "' "

            users _user = new users();
            _user = userManager.SelectByFilter("user","EmailAdress ='"+mail+"'");
            if (_user == null)
                return new ErrorDataResult<users>(_user,ResultMessage.ErrorSystem);
            if(_user.Id!=0)
                return new SuccessDataResult<users>(_user);
            return new ErrorDataResult<users>(_user, ResultMessage.ErrorUser);

        }
    }
}

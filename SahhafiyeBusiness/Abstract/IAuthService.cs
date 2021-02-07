using SahafiyeCore.Utilitis.Result.Abstract;
using SahafiyeCore.Utilitis.Security.JWT;
using SahhafiyeEntities.Dto;
using SahhafiyeEntities.UsersEntity;

namespace SahhafiyeBusiness.Abstract
{
    public interface IAuthService
    {
        IResult UserRegister(ForRegisterDto registerDto);
        IDataResult<AccessToken> UserLogin(ForLoginDto loginDto);
    }
}

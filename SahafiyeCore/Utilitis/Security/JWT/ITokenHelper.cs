using SahafiyeCore.Entities.Concreate;
namespace SahafiyeCore.Utilitis.Security.JWT
{
    interface ITokenHelper
    {
        AccessToken CreateToken(UserInfo userInfo);
    }
}

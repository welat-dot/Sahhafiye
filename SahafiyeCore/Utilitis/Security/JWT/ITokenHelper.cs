using SahafiyeCore.Entities.Concreate;
namespace SahafiyeCore.Utilitis.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserInfo userInfo);
    }
}

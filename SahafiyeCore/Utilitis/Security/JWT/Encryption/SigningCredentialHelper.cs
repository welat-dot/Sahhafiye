using Microsoft.IdentityModel.Tokens;

namespace SahafiyeCore.Utilitis.Security.JWT.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
        }
    }
}

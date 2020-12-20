using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace SahafiyeCore.Extension
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, value: email));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(type: ClaimTypes.Name, value: name));
        }
        public static void AddNameIdentityfier(this ICollection<Claim> claims, string nameIdentityfier)
        {
            claims.Add(new Claim(type: ClaimTypes.NameIdentifier, value: nameIdentityfier));
        }
        public static void AddRoles(this ICollection<Claim> claims, string roles)
        {
            claims.Add(new Claim(type:ClaimTypes.Role, value: roles));

        }
        public static void AddAuthority(this ICollection<Claim> claims, string [] authoritys)
        {
            authoritys.ToList().ForEach(authority => claims.Add(new Claim(type: ClaimTypes.Actor, value: authority)));

        }
    }
}

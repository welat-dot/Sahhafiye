using System;

namespace SahafiyeCore.Utilitis.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

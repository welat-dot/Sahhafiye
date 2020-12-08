using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SahafiyeCore.Entities.Concreate;
using SahafiyeCore.Extension;
using SahafiyeCore.Utilitis.Security.JWT.Encryption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SahafiyeCore.Utilitis.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {            
            this.configuration = configuration;
            _tokenOptions = configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();           
        }

        public AccessToken CreateToken(UserInfo userInfo)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var jwt = CreateJwtSecurityToken(tokenOptions: _tokenOptions,userInfo:userInfo, signingCredentials: signingCredentials);
            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = JwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration

            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserInfo userInfo, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(userInfo),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(UserInfo userInfo)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentityfier(userInfo.Id.ToString());
            claims.AddEmail(userInfo.email);
            claims.AddName(userInfo.Name);
            claims.AddRoles(userInfo.Role.ToArray());
            claims.AddAuthority(userInfo.Authority.ToArray());
            return claims;
        }

    }
    
}

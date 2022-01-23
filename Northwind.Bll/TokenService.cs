using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Northwind.Entity.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class TokenService
    {
        IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Token oluşturur
        public string CreateAccessToken(DtoUser dtoUser)
        {
            //claims oluşturmak
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, dtoUser.UserCode),
                new Claim(JwtRegisteredClaimNames.Jti, dtoUser.UserID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //claims roller
            var claimsRoleList = new List<Claim>()
            {
                new Claim("role","Admin"),
                new Claim("role2","OperationUser")
            };

            //securityKey'in simetriğini alma
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            //şifrelenmiş kimlik oluşturma
            var cred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //token ayarları
            var token = new JwtSecurityToken
                (
                issuer: _configuration["Tokens:Issuer"], //Token dağıtıcı url
                audience: _configuration["Tokens:Audience"], //Erişilebilecek api'ler
                expires: DateTime.Now.AddMinutes(5), //Token süresi
                notBefore: DateTime.Now, //Token üretildikten sonra ne kadar süre sonra devreye girmeli
                signingCredentials: cred, //Kimlik tanımlanır
                claims: claimsIdentity.Claims //Claimsler verilir
                );

            //token oluşturma sınıfı ile örnek alıp token üretme
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
    }
}

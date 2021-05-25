using Microsoft.IdentityModel.Tokens;
using PIA_Backend.Database;
using PIA_Backend.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PIA_Backend.Backend
{
    public class TokenService
    {
        NORTHWNDContext DataContext = new NORTHWNDContext();

        public string GetToken(UserModel userData)
        {
            var user = DataContext.Users.Where(w => w.UserName == userData.UserName).FirstOrDefault();

            if (user.Password == userData.Password)
                return GenerateJSONWebToken(user.UserName);

            return null;
        }

        //https://www.c-sharpcorner.com/blogs/simple-jwt-token-generation-process-in-net-core-web-api
        public string GenerateJSONWebToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.privateKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("userName", userName));


            var token = new JwtSecurityToken(Constants.issuer,
              Constants.audience, claims: permClaims,
              null,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            //TODO: get time from token object

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

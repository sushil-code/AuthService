using AuthenticationService.DTO;
using AuthenticationService.Models;
using AuthenticationService.UsersData;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private readonly Users _user;
        private readonly IConfiguration _configuration;
        public AuthRepository(Users user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        
        public AuthenticatedUserDTO Login(LoginModel loginModel)
        {
            var validUser = _user.users.Where(l => l.Email == loginModel.Email && l.Password == loginModel.Password).FirstOrDefault();
            if (validUser == null)
                return null;
            AuthenticatedUserDTO authuser = new AuthenticatedUserDTO();
            authuser.MemberId = validUser.MemberId;
            authuser.Name = validUser.Name;
            authuser.Token = GenerateToken(loginModel);
            return authuser;
        }

        private string GenerateToken(LoginModel loginModel)
        {
            string Key = _configuration["Token:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //string userRole = "Member";

            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", loginModel.Email)
            };

            var token = new JwtSecurityToken(
            issuer: _configuration["Token:Issuer"],
            audience: _configuration["Token:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(15),
            signingCredentials: credentials);
           
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

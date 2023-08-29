using Domain.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenCar.Authorization
{
    public class Authentication : IAuthentication<UsersModel>
    {
        public IConfiguration Configuration { get; }
        public Authentication(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        public string GetJsonWebToken(UsersModel entity)
        {
            var Securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var Credentials=new SigningCredentials(Securitykey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId,entity.UsersId),
                new Claim(JwtRegisteredClaimNames.Name,entity.First_Name),
                new Claim(JwtRegisteredClaimNames.FamilyName,entity.Last_Name),
                new Claim(JwtRegisteredClaimNames.Email,entity.Email),
                new Claim(JwtRegisteredClaimNames.Azp,entity.Address),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())


            };
            var token = new JwtSecurityToken(

                issuer: Configuration["Jwt:Issuer"],
                audience: Configuration["Jwt:Audience"],
                claims: claims,
                expires: Convert.ToDateTime(DateTime.Now.AddDays(1)),
                signingCredentials: Credentials

             ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

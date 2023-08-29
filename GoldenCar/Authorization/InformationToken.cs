using System.IdentityModel.Tokens.Jwt;
using static Domain.Common.CommonClass;

namespace GoldenCar.Authorization
{
    public class InformationToken
    {
       public static JwtAuthResponce GetInfoUser(string strtoken)
        {
            var handler= new JwtSecurityTokenHandler();
            var JwtToken=handler.ReadJwtToken(strtoken.Replace("Bearer ", ""));
            var InfoDecrypt= SecuredHelper.GetInfoFromToken(JwtToken.ToString());
            return InfoDecrypt;

        }
    }
}

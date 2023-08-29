using Nancy.Json;
using static Domain.Common.CommonClass;

namespace GoldenCar.Authorization
{
    public class SecuredHelper
    {
        public static JwtAuthResponce GetInfoFromToken(string token)
        {
            JavaScriptSerializer serializer= new JavaScriptSerializer();
            string[] source = token.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            JwtAuthResponce authResponce = serializer.Deserialize<JwtAuthResponce>(source[1]);
            return authResponce;

        }
    }
}

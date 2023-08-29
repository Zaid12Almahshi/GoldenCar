using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Helpers;
using static Domain.Common.CommonClass;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsrerLoginModel colloction)
        {
            using (var client=new HttpClient())
            {

                try
                {
                    client.BaseAddress = new Uri(CommonWeb.UrlApi);
                    var PostTask = await client.PostAsJsonAsync<UsrerLoginModel>("api/Users/UserLogin", colloction);
                    if (PostTask.IsSuccessStatusCode)
                    {
                        var result = PostTask.Content.ReadAsStringAsync().Result;
                        ResponseStandardJson<UsersModel> ResultData = (ResponseStandardJson<UsersModel>)JsonConvert.DeserializeObject(result.ToString(), (typeof(ResponseStandardJson<UsersModel>)));
                        CookieOptions optionUsers=new CookieOptions();
                        optionUsers.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Append("_CookResultData", JsonConvert.SerializeObject(ResultData), optionUsers);
                        return RedirectToAction("Index", "Payment");
                    }

                }
                catch (Exception)
                {

                    throw;
                }

                return View();


            }




            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, CommonWeb.UrlApi + "api/User/Login");
            //var content = new StringContent("{\r\n  \"userName\": \"zaid\",\r\n  \"password\": \"123456\"\r\n}", null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);
            ////response.EnsureSuccessStatusCode();
            ////Console.WriteLine(await response.Content.ReadAsStringAsync());
            //var data = await response.Content.ReadAsStringAsync();
            //return View(data);




        }
    }
}

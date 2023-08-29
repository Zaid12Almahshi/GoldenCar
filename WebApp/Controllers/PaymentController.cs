using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Helpers;
using static Domain.Common.CommonClass;

namespace WebApp.Controllers
{
    public class PaymentController : Controller
    {
        // GET: PaymentController
        public async Task<ActionResult> Index()
        {
            using (var client =new HttpClient())
            {
                try
                {
                    var stringcontent = new StringContent("", Encoding.UTF8, "application/json");
                    ResponseStandardJson<UsersModel> ResData = (ResponseStandardJson<UsersModel>)JsonConvert.DeserializeObject(Request.Cookies["_CookResultData"].ToString(),(typeof(ResponseStandardJson<UsersModel>)));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ResData.Result.Token);
                    client.BaseAddress = new Uri(CommonWeb.UrlApi);
                    var PostTask = await client.PostAsJsonAsync("api/Payment/GetPaymentList", stringcontent);
                    if (PostTask.IsSuccessStatusCode)
                    {
                        var result = PostTask.Content.ReadAsStringAsync().Result;
                        ResponseStandardJson<IList<PaymentModel>> Resultdata=(ResponseStandardJson<IList<PaymentModel>>)JsonConvert.DeserializeObject(result.ToString(),(typeof(ResponseStandardJson<IList<PaymentModel>>)));
                        return View(Resultdata.Result);
                    }
                }
                catch (Exception)
                {


                    throw;
                }
            }
            return View();
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

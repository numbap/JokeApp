using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using JokeApp.Models;


namespace JokeApp.Controllers
{
    public class HomeController : Controller
    {
         string baseURL = "https://1dt6edq6vh.execute-api.us-east-1.amazonaws.com/prod/scan";

        public async  Task <ActionResult> Index()
        {
            // Calling the web api and populating the data in veiw using datatable
            VisionLabels dt = new VisionLabels();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("");

                if (getData.IsSuccessStatusCode)
                {
                    var results = getData.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<VisionLabels>(results);
                }
                else
                {
                    Console.WriteLine("Error Calling Web API");
                }
            }
            
            return View(dt);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
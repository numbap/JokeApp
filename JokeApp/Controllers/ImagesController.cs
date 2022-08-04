using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JokeApp.Models;
using Newtonsoft.Json;

namespace JokeApp.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Images
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        // GET: ShowSearchForm
        public ActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: ShowSearchResults
        [HttpPost]
        public ActionResult ShowSearchResults(string SearchPhrase)
        {

            return View("Index", db.Images.ToList());
        }

        // GET: Images/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }

            string baseURL = "https://1dt6edq6vh.execute-api.us-east-1.amazonaws.com/prod/scan?BucketName=" + images.BucketName + "&ImageName=" + images.ImageName + "&AwsRegion=" + images.AwsRegion;

            // Calling the web api and populating the data in veiw using datatable
            VisionLabels dt = new VisionLabels();

            using (var client = new HttpClient())
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

                if (dt.Labels != null)
                {
                    if (dt.Labels.Length == 1)
                    {
                        images.Message = dt.Labels.FirstOrDefault().Name;
                    }

                    if (dt.Labels.Length == 0 || dt.Labels == null)
                    {
                        images.Message = "All Colors";
                    }
                    if (dt.Labels.Length > 1)
                    {
                        images.Message = dt.Labels.Where(x => (x.Name != "AllColors")).FirstOrDefault().Name + " - Contaminated";
                    }
                }


                images.vl = dt;
                images.AwsUrl = baseURL;
            }

            return View(images);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Images images)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(images);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(images);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Images images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(images).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(images);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Images images = db.Images.Find(id);
            db.Images.Remove(images);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

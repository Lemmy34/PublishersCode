using ADMpublishers.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ADMpublishers.web.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<AuthorViewModel> authors = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Authors");
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataTask =  response.Content.ReadAsStringAsync();

                    dataTask.Wait();

                     authors = JsonConvert.DeserializeObject<List<AuthorViewModel>>(dataTask.Result);

                }
                else 
                {
             
                    authors = Enumerable.Empty<AuthorViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(authors);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
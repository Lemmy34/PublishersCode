using ADMpublishers.Core.Services;
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
        private IAuthorService _authorservice;
        public AuthorController(IAuthorService authorservice)
        {
            _authorservice = authorservice;
        }
        public ActionResult Index()
        {
            IEnumerable<AuthorViewModel> authors = null;

            var response = _authorservice.GetAllAuthors();

                if (!string.IsNullOrEmpty(response))
                {
                     authors = JsonConvert.DeserializeObject<List<AuthorViewModel>>(response);

                }
                else 
                {
             
                    authors = Enumerable.Empty<AuthorViewModel>();
                }
            
            return View(authors);
        }

        // GET: Default/Details/5
        public ActionResult Details(string id)
        {
            AuthorViewModel author = null;

            var response = _authorservice.GetSingleAuthor(id);

            if (!string.IsNullOrEmpty(response))
            {
                author = JsonConvert.DeserializeObject<AuthorViewModel>(response);

            }
            else
            {

                author = new AuthorViewModel();
            }

            return View(author);
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
        public ActionResult Edit(string id)
        {
            AuthorViewModel author = null;

            var response = _authorservice.GetSingleAuthor(id);

            if (!string.IsNullOrEmpty(response))
            {
                author = JsonConvert.DeserializeObject<AuthorViewModel>(response);

            }
            else
            {

                author = new AuthorViewModel();
            }

            return View(author);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
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
        public ActionResult Delete(string id)
        {
            AuthorViewModel author = null;

            var response = _authorservice.GetSingleAuthor(id);

            if (!string.IsNullOrEmpty(response))
            {
                author = JsonConvert.DeserializeObject<AuthorViewModel>(response);

            }
            else
            {

                author = new AuthorViewModel();
            }

            return View(author);
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mouha.DemoAspNetCoreGithub.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Route("admin/[controller]/[action]")]
    [Route("admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("details/{id}")]
        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(id);
        }
        [Route("Create"), HttpGet]
        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create"), HttpPost]
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

        // GET: HomeController/Edit/5
        [Route("Edit/{id}"), HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit"), HttpPost]
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

        // GET: HomeController/Delete/5
        [Route("Delete/{id}"), HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete"), HttpPost]
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

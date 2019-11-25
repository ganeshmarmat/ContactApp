using DataModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(MvcApplication.DataSource.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(ContactDetailsModel contactDetails)
        {
            if (ModelState.IsValid)
            {
                MvcApplication.DataSource.Edit(contactDetails);
                return RedirectToAction("Index");
            }
            return View(contactDetails);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContactDetailsModel contactDetails)
        {
            if (ModelState.IsValid)
            {
                MvcApplication.DataSource.Add(contactDetails);
                return RedirectToAction("index");
            }
            return View(contactDetails);
        }
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View(MvcApplication.DataSource.GetAll());
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(MvcApplication.DataSource.GetById(id));
        }
        [HttpPost]
        public ActionResult Delete(ContactDetailsModel contactDetails)
        {
            MvcApplication.DataSource.Remove(contactDetails);
            return RedirectToAction("Index");
        }
    }
}
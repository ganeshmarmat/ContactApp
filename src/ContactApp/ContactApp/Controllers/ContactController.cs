using ContactApp.Models;
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
        static List<ContactDetails> lstcd = new List<ContactDetails>();
        static ContactController()
        {
            lstcd.Add(new ContactDetails { Id = "1", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
            lstcd.Add(new ContactDetails { Id = "2", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
            lstcd.Add(new ContactDetails { Id = "3", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
            lstcd.Add(new ContactDetails { Id = "4", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
            lstcd.Add(new ContactDetails { Id = "5", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
            lstcd.Add(new ContactDetails { Id = "6", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
            lstcd.Add(new ContactDetails { Id = "7", FirstName = "ganesh", LastName = "marmat", Email = "ganeshmarmat@gamil.com", PhoneNumber = "12341234", Status = Status.Active });
        }

        public ActionResult Edit(string id)
        {
            return View(lstcd.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(ContactDetails cd)
        {
            if (ModelState.IsValid)
            {
                lstcd[lstcd.IndexOf(lstcd.FirstOrDefault(x => x.Id == cd.Id))] = cd;
                return RedirectToAction("Index");
            }
            return View(cd);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                lstcd.Add(contactDetails);
                return RedirectToAction("index");
            }
            return View(contactDetails);
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View(lstcd);
        }
        public ActionResult Delete(string id)
        {
            return View(lstcd.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Delete(ContactDetails contactDetails)
        {
            lstcd.RemoveAll(x => x.Id == contactDetails.Id);
            return RedirectToAction("Index");
        }
    }
}
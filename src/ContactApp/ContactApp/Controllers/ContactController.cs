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
        /// <summary>
        /// This Edit Action method return the view for Edit filled with given id record
        /// </summary>
        /// <param name="id">Id of existing record</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(MvcApplication.DataSource.GetById(id));
        }

        /// <summary>
        /// This Action method is for POST abbrevation to save the Edited record 
        /// </summary>
        /// <param name="contactDetails">Model object filled with information</param>
        /// <returns></returns>
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

        /// <summary>
        /// This Action method allow for get request to return view for Edit record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// After filled all detail of contact, this action help to save the record 
        /// </summary>
        /// <param name="contactDetails">new contact filled with record</param>
        /// <returns></returns>
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
        /// <summary>
        /// Default Action return all contact list from database
        /// </summary>
        /// <returns>return all Contacts</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(MvcApplication.DataSource.GetAll());
        }
        /// <summary>
        /// this action method return delete view for confirmation
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return delete view</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(MvcApplication.DataSource.GetById(id));
        }
        /// <summary>
        /// this Post Action method remove the selected record from the database and navigate to home page
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(ContactDetailsModel contactDetails)
        {
            MvcApplication.DataSource.Remove(contactDetails);
            return RedirectToAction("Index");
        }
    }
}
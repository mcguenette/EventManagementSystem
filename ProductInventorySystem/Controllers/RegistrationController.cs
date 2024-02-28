using EMSBLL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private RegistrationService rs;

        public RegistrationController()
        {
            rs = new RegistrationService();
        }

        // GET: Registration
        public ActionResult Index()
        {
            List<Registration> registrations = rs.GetRegistrations();
            return View(registrations);
        }

        // GET: Registration/Create
        public ActionResult CreateRegistration()
        {
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        public ActionResult CreateRegistration(Registration registration)
        {
            try
            {
                rs.AddRegistration(registration);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Edit/5
        public ActionResult EditRegistration(int id)
        {
            Registration registration = rs.GetRegistrationById(id);
            return View(registration);
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult EditRegistration(int id, Registration registration)
        {
            try
            {
                rs.UpdateRegistration(registration);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult DeleteRegistration(int id)
        {
            Registration registration = rs.GetRegistrationById(id);
            return View(registration);
        }

        // POST: Registration/Delete/5
        [HttpPost]
        public ActionResult DeleteRegistration(int id, FormCollection collection)
        {
            try
            {
                rs.DeleteRegistration(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
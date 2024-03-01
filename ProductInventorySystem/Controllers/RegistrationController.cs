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
        private EventService es;

        public RegistrationController()
        {
            rs = new RegistrationService();
            es = new EventService();
        }

        public ActionResult Index() 
        {
            try
            {
                var registrations = rs.GetRegistrations();
                return View(registrations);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving registrations", ex);

            }
        }

        public ActionResult CreateRegistration()
        {
            var events = es.GetEvents();
            SelectList eventList = new SelectList(events, "EventID", "EventName");
            ViewBag.EventList = eventList;

            return View();
        }

        // POST: Create a new registration.
        [HttpPost]
        public ActionResult CreateRegistration(Registration registration)
        {
            if(rs.AddRegistrationService(registration))
            {
                ViewBag.Message = "Registration added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                var events = es.GetEvents();
                SelectList eventList = new SelectList(events, "EventID", "EventName");
                ViewBag.EventList = eventList;

                ViewBag.Message = "Failed to add registration";
                return View("CreateRegistration", registration);
            }
        }
        public ActionResult UpdateRegistration(int registrationID)
        {
            var registrationList = rs.GetRegistrations();
            var registrations = registrationList.FirstOrDefault(x => x.RegistrationID == registrationID);

            if (registrations == null)
            {
                ViewBag.Message = "Registration not found.";
                return View("UpdateRegistration", registrations);
            }

            var events = es.GetEvents();
            SelectList eventList = new SelectList(events, "EventID", "EventName", registrations.EventID);
            ViewBag.EventList = eventList;
            return View(registrations);
        }

        public ActionResult DeleteRegistration(int registrationID)
        {
            if (rs.DeleteRegistrationService(registrationID))
            {
                return RedirectToAction("Index");
            }
            return null;
        }
    }

}
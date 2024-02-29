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
                throw new Exception("An error occurred while retrieving registrations.", ex);

            }
        }

        // GET: Display the form to create a new registration.
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
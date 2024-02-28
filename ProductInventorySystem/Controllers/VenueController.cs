using EMSBLL;
using EventManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class VenueController : Controller
    {
        private readonly VenueService vs;

        public VenueController()
        {
            vs = new VenueService();
        }

        public ActionResult Index()
        {
            // Logic to fetch venues from the service layer
            var venues = vs.GetVenues();
            return View(venues);
        }


    }
}
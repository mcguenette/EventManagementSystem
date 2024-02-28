using EMSBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class VenueController : Controller
    {
        private VenueService venueService;

        public VenueController()
        {
            venueService = new VenueService();
        }

        public ActionResult Index()
        {
            // Logic to fetch venues from the service layer
            var venues = venueService.GetVenues();
            return View(venues);
        }
    }
}
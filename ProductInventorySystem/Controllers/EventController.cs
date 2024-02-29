using EMSBLL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private EventService es;
        private readonly VenueService vs = new VenueService();

        /// <summary>
        /// Constructor to initialize the EventService.
        /// </summary>
        public EventController()
        {
            es = new EventService();
        }

        /// <summary>
        /// GET: Display a list of all events.
        /// </summary>
        /// <returns>List of events.</returns>
        //public ActionResult Index()
        //{
        //    var events = es.GetEvents();
        //    // Retrieve the list of events from the service
        //    return View(events);
        //}
        public ActionResult Index()
        {
            try
            {
                var events = es.GetEvents();
                return View(events);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving events.", ex);

            }
        }


        /// <summary>
        /// GET: Display the form to create a new event.
        /// </summary>
        /// <returns>Form to create a new event.</returns>
         public ActionResult CreateEvent()
        {
            var venues = vs.GetVenues();
            SelectList venueList = new SelectList(venues, "VenueID", "VenueName");
            ViewBag.VenueList = venueList;

            return View();
        }


        /// <summary>
        /// POST: Create a new event.
        /// </summary>
        /// <param name="event">Event object to be added.</param>
        /// <returns>Redirects to the index page after successful addition.</returns>
        [HttpPost]
        public ActionResult CreateEvent(Event @event)
        {
            if (es.AddEventService(@event))
            {
                ViewBag.Message = "Event was added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                var venues = vs.GetVenues();
                SelectList venueList = new SelectList(venues, "VenueID", "VenueName");

                ViewBag.VenueList = venueList;

                ViewBag.Message = "Failed to add event";
                return View("CreateEvent", @event);
            }
        }


        /// <summary>
        /// GET: Display the form to edit an existing event.
        /// </summary>
        /// <param name="id">ID of the event to be edited.</param>
        /// <returns>Form to edit the event.</returns>
        public ActionResult EditEvent(int eventID)
        {
            // Retrieve the event with the specified ID from the service
            var @event = es.GetEvents().Find(x => x.EventID == eventID);

            //if (@event == null)
            //{
            //    return HttpNotFound();
            //}

            return View(@event);
        }

        /// <summary>
        /// POST: Update an existing event.
        /// </summary>
        /// <param name="id">ID of the event to be updated.</param>
        /// <param name="event">Updated event object.</param>
        /// <returns>Redirects to the index page after successful update.</returns>
        [HttpPost]
        public ActionResult EditEvent(int eventID, Event @event)
        {
            try
            {
                @event.EventID = eventID;
                es.UpdateEventService(@event);
                ViewBag.Message = "Event was updated successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(@event);
            }
        }

        /// <summary>
        /// GET: Display the confirmation dialog to delete an event.
        /// </summary>
        /// <param name="id">ID of the event to be deleted.</param>
        /// <returns>Confirmation dialog to delete the event.</returns>
        //public ActionResult DeleteEvent(int eventID)
        //{
        //    // Retrieve the event with the specified ID from the service
        //    var @event = es.GetEvents().Find(x => x.EventID == eventID);

        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(@event);
        //}

        /// <summary>
        /// POST: Delete an existing event.
        /// </summary>
        /// <param name="id">ID of the event to be deleted.</param>
        /// <returns>Redirects to the index page after successful deletion.</returns>
        public ActionResult DeleteEvent(int eventID) 
        {

            if (es.DeleteEventService(eventID))
            {
                return RedirectToAction("Index");
            }
            return null;
       
        }
    }
}
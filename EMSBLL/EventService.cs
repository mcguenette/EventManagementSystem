using EMSDAL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSBLL
{
    public class EventService
    {
        private EventRepo er;
        public EventService()
        {
            er = new EventRepo();
        }
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            if (er != null)
            {
                events = er.GetEvents();
            }
            else
            {
               
                // Optionally handle the case where er is null
                // You could log an error, throw an exception, or take other appropriate action
            }

            return events;
        }

        public bool AddEventService(Event @event)
        {

            return er.AddEvent(@event);
        }

        public bool UpdateEvent(Event @event)
        {
            return er.UpdateEvent(@event);
        }

        public bool DeleteEventService(int eventID)
        {
            return er.DeleteEvent(eventID);
        }
     }
 }

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

            }

            return events;
        }

        public bool AddEventService(Event @event)
        {

            return er.AddEvent(@event);
        }

        public bool UpdateEventService(Event @event)
        {
            return er.UpdateEvent(@event);
        }

        public bool DeleteEventService(int eventID)
        {
            return er.DeleteEvent(eventID);
        }
     }
 }

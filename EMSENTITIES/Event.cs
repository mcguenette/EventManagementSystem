using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSENTITIES
{
    public class Event
    {
        public int EventID { get; set; }
        public int VenueID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventDuration { get; set; }
        public float EventTicketPrice { get; set; }
        public string VenueName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Event Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
        [DisplayName("Event Start Time")]
        public TimeSpan EventDuration { get; set; }
        public float EventTicketPrice { get; set; }
        public string VenueName { get; set; }
    }
}

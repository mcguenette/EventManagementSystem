using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Models
{
    public class CreateEventViewModel
    {
        public List<SelectListItem> VenueList { get; set; }
        public Event Event { get; set; }
    }

}
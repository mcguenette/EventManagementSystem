using EMSDAL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSBLL
{
    public class VenueService
    {
        private VenueRepo venueRepo;
        public VenueService()
        {
            venueRepo = new VenueRepo();
        }
        public List<Venue> GetVenues()
        {
            return venueRepo.GetVenues();
        }
    }
}

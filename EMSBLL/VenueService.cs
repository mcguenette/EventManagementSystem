using EMSDAL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace EMSBLL
{
    public class VenueService
    {
        private readonly VenueRepo venueRepo;
        private readonly string connectionString;

        public VenueService()
        {
            connectionString = EMSDAL.Connection.ConnectionString;
            venueRepo = new VenueRepo(connectionString);
        }

        public VenueService(string connectionString)
        {
            this.connectionString = connectionString;
            venueRepo = new VenueRepo(connectionString);
        }
        public List<Venue> GetVenues()
        {
            return venueRepo.GetVenues();
        }
    }
}




using EMSDAL;
using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // Add this namespace for SqlConnection

namespace EMSBLL
{
    public class VenueService
    {
        private readonly VenueRepo venueRepo;
        private readonly string connectionString;

        // Default constructor without parameters
        public VenueService()
        {
            connectionString = EMSDAL.Connection.ConnectionString;
            venueRepo = new VenueRepo(connectionString);
        }

        // Constructor with connectionString parameter
        public VenueService(string connectionString)
        {
            this.connectionString = connectionString;
            venueRepo = new VenueRepo(connectionString);
        }

        // Rest of the class remains unchanged...
        public List<Venue> GetVenues()
        {
            return venueRepo.GetVenues();
        }
    }
}




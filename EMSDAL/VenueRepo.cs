using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDAL
{
    public class VenueRepo
    {
        private string connectionString;

        public VenueRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public VenueRepo()
        {
        }
        public List<Venue> GetVenues()
        {
            List<Venue> venues = new List<Venue>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_GetVenues";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Venue venue = new Venue
                    {
                        VenueID = Convert.ToInt32(reader["VenueID"]),
                        VenueName = Convert.ToString(reader["VenueName"]),
                        VenueLocation = Convert.ToString(reader["VenueLocation"])
                    };
                    venues.Add(venue);
                }
                reader.Close();
            }

            return venues;
        }

        public bool AddVenue(Venue venue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_AddVenue";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@VenueName", venue.VenueName);
                sqlCommand.Parameters.AddWithValue("@VenueLocation", venue.VenueLocation);
                conn.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateVenue(Venue venue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_UpdateVenue";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@VenueID", venue.VenueID);
                sqlCommand.Parameters.AddWithValue("@VenueName", venue.VenueName);
                sqlCommand.Parameters.AddWithValue("@VenueLocation", venue.VenueLocation);
                conn.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteVenue(int venueID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@VenueID", venueID);
                conn.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

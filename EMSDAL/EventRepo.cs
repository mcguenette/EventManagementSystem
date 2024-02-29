using EMSENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDAL
{
    public class EventRepo
    {
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                string commandText = "usp_GetAllEvents";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    events.Add(
                        new Event
                        {
                            EventID = Convert.ToInt32(dr["EventID"]),
                            VenueID = Convert.ToInt32(dr["VenueID"]),
                            EventName = Convert.ToString(dr["EventName"]),
                            EventDescription = Convert.ToString(dr["EventDescription"]),
                            EventDate = Convert.ToDateTime(dr["EventDate"]),
                            EventDuration = TimeSpan.Parse(Convert.ToString(dr["EventDuration"])),
                            EventTicketPrice = Convert.ToSingle(dr["EventTicketPrice"])
                        }
                    );
                }

                return events;
            }
        }

        public bool AddEvent(Event @event)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_AddEvent", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                string eventDurationStr = @event.EventDuration.ToString(@"hh\:mm\:ss");

                sqlCommand.Parameters.AddWithValue("@VenueID", @event.VenueID);
                sqlCommand.Parameters.AddWithValue("@EventName", @event.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDescription", @event.EventDescription);
                sqlCommand.Parameters.AddWithValue("@EventDate", @event.EventDate);
                sqlCommand.Parameters.AddWithValue("@EventDuration", eventDurationStr);
                sqlCommand.Parameters.AddWithValue("@EventTicketPrice", @event.EventTicketPrice);

                try
                {
                    conn.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    conn.Close();

                    return i > 0; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateEvent(Event @event)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                string commandText = "usp_UpdateEvent";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", @event.EventID);
                sqlCommand.Parameters.AddWithValue("@VenueID", @event.VenueID);
                sqlCommand.Parameters.AddWithValue("@EventName", @event.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDescription", @event.EventDescription);
                sqlCommand.Parameters.AddWithValue("@EventDate", @event.EventDate);
                sqlCommand.Parameters.AddWithValue("@EventDuration", @event.EventDuration.ToString());
                sqlCommand.Parameters.AddWithValue("@EventTicketPrice", @event.EventTicketPrice);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteEvent(int eventID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                string commandText = "usp_DeleteEvent";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EventID", eventID);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

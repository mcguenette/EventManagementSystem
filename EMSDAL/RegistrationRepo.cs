using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSENTITIES;

namespace EMSDAL
{
    public class RegistrationRepo
    {
        private string connectionString;

        public RegistrationRepo()
        {
            connectionString = Connection.ConnectionString;
        }

        public List<Registration> GetRegistrations()
        {
            List<Registration> registrations = new List<Registration>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_GetAllRegistrations";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Registration registration = new Registration
                    {
                        RegistrationID = Convert.ToInt32(reader["RegistrationID"]),
                        EventID = Convert.ToInt32(reader["EventID"]),
                        RegistrationName = reader["RegistrationName"].ToString(),
                        RegistrationEmail = reader["RegistrationEmail"].ToString(),
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]),
                        RegistrationFee = Convert.ToSingle(reader["RegistrationFee"])
                    };
                    registrations.Add(registration);
                }

                conn.Close();
            }

            return registrations;
        }


        public bool AddRegistration(Registration registration)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_AddRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", registration.EventID);
                sqlCommand.Parameters.AddWithValue("@RegistrationName", registration.RegistrationName);
                sqlCommand.Parameters.AddWithValue("@RegistrationEmail", registration.RegistrationEmail);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                sqlCommand.Parameters.AddWithValue("@RegistrationFee", registration.RegistrationFee);

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

        public bool UpdateRegistration(Registration registration)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_UpdateRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@RegistrationID", registration.RegistrationID);
                sqlCommand.Parameters.AddWithValue("@EventID", registration.EventID);
                sqlCommand.Parameters.AddWithValue("@RegistrationName", registration.RegistrationName);
                sqlCommand.Parameters.AddWithValue("@RegistrationEmail", registration.RegistrationEmail);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                sqlCommand.Parameters.AddWithValue("@RegistrationFee", registration.RegistrationFee);

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

        public bool DeleteRegistration(int registrationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string commandText = "usp_DeleteRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RegistrationID", registrationID);

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


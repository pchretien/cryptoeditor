using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace CryptoEditorService
{
    public class CryptoEditorServiceDaoMsSql : ICryptoEditorServiceDaoInterface
    {
        public int LicenseExist(string email, string license)
        {
            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);

            try
            {
                connection.Open();

                SqlCommand command =
                    new SqlCommand("select count(*) from ce_user where email = @email and license = @license",
                                   connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@license", license));

                int count = (int)command.ExecuteScalar();
                return count;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int ProfileExist(string email)
        {
            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            
            try
            {
                connection.Open();

                SqlCommand command =
                    new SqlCommand("select count(*) from ce_user where email = @email",
                                   connection);
                command.Parameters.Add(new SqlParameter("@email", email));

                int count = (int)command.ExecuteScalar();
                return count;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int GetStatus(string email, ref int status, ref string license, ref DateTime expiration)
        {
            SqlDataReader reader = null;

            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);

            try
            {
                connection.Open();

                SqlCommand command =
                    new SqlCommand("select status, license, expiration from ce_user where email = @email", 
                    connection);
                command.Parameters.Add(new SqlParameter("@email", email));

                reader = command.ExecuteReader();
                if (!reader.HasRows)
                    return 0;

                if (reader.Read())
                {
                    status = Convert.ToInt32(reader["status"]);
                    license = Convert.ToString(reader["license"]);
                    expiration = Convert.ToDateTime(reader["expiration"]);

                    return 1;
                }

                return 0;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int GetEncryptedLicense(string email, ref string encryptedLicense)
        {
            SqlDataReader reader = null;

            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select encrypted_license from ce_user where email = @email", connection);
                command.Parameters.Add(new SqlParameter("@email", email));

                reader = command.ExecuteReader();
                if (!reader.HasRows)
                    return 0;

                if (reader.Read())
                {
                    encryptedLicense = Convert.ToString(reader["encrypted_license"]);
                    return 1;
                }

                return 0;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int UpdateEncryptedKey(string email, string license, string encryptedLicense)
        {
            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select count(*) from ce_user where email = @email and license = @license", connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@license", license));

                int count = (int)command.ExecuteScalar();
                if (count == 0)
                    return count;

                command = new SqlCommand( "update ce_user set encrypted_license = @encrypted_license where email = @email and license = @license", connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@license", license));
                command.Parameters.Add(new SqlParameter("@encrypted_license", encryptedLicense));

                int updated = command.ExecuteNonQuery();
                return updated;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int Confirm(string email, string license, string encryptedLicense, ref string fullname, ref string profile)
        {
            string sqlConnectionString = (string)System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            try
            {
                connection.Open();

                // Check if the data exist ...
                SqlCommand command =
                    new SqlCommand("select count(*) from ce_user where email = @email and license = @license",
                                   connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@license", license));

                int count = (int) command.ExecuteScalar();
                if (count == 0)
                    return count;

                command =
                    new SqlCommand(
                        "update ce_user set status = @status, expiration = @expiration, lastupdate = @lastupdate, encrypted_license = @encrypted_license where email = @email and license = @license",
                        connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@license", license));
                command.Parameters.Add(new SqlParameter("@encrypted_license", encryptedLicense));
                command.Parameters.Add(new SqlParameter("@status", Convert.ToInt32(1)));
                command.Parameters.Add(new SqlParameter("@expiration", DateTime.Now.AddMonths(3)));
                command.Parameters.Add(new SqlParameter("@lastupdate", DateTime.Now));

                int updated = command.ExecuteNonQuery();
                if (updated == 0)
                {
                    return updated;
                }

                command =
                    new SqlCommand("select fullname, profile from ce_user where email = @email and license = @license",
                                   connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@license", license));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    fullname = Convert.ToString(reader["fullname"]);
                    profile = Convert.ToString(reader["profile"]);
                    
                    return 1;
                }

                return 0;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int Register(string email, string profile, string fullName, ref string license)
        {
            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            
            try
            {
                connection.Open();
                
                // Generate the license key for that user
                license = Guid.NewGuid().ToString();

                SqlCommand command = new SqlCommand("insert into ce_user (email,profile,fullname,license,encrypted_license,status,expiration,lastupdate) values( @email,@profile,@fullname,@license,@encrypted_license,@status,@expiration,@lastupdate)", connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@profile", profile));
                command.Parameters.Add(new SqlParameter("@fullname", fullName));
                command.Parameters.Add(new SqlParameter("@license", license));
                command.Parameters.Add(new SqlParameter("@encrypted_license", ""));
                command.Parameters.Add(new SqlParameter("@status", Convert.ToInt32(0)));
                command.Parameters.Add(new SqlParameter("@expiration", DateTime.Now));
                command.Parameters.Add(new SqlParameter("@lastupdate", DateTime.Now));

                int inserted = command.ExecuteNonQuery();
                return inserted;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int Save(string email, string license, string plugin, string xml)
        {
            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);

            try
            {
                connection.Open();

                // Check if the data exist ...
                SqlCommand command = new SqlCommand("select count(*) from ce_data where email = @email and plugin = @plugin", connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@plugin", plugin));

                int count = (int)command.ExecuteScalar();
                if (count == 0)
                {
                    command = new SqlCommand("insert into ce_data (email,plugin,data,lastupdate) values( @email,@plugin, @data, @lastupdate)", connection);
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@plugin", plugin));
                    command.Parameters.Add(new SqlParameter("@data", xml));
                    command.Parameters.Add(new SqlParameter("@lastupdate", DateTime.Now));

                    int inserted = command.ExecuteNonQuery();
                    return inserted;
                }
                else
                {
                    command = new SqlCommand("update ce_data set data = @data, lastupdate = @lastupdate where email = @email and plugin = @plugin", connection);
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@plugin", plugin));
                    command.Parameters.Add(new SqlParameter("@data", xml));
                    command.Parameters.Add(new SqlParameter("@lastupdate", DateTime.Now));

                    int updated = command.ExecuteNonQuery();
                    return updated;
                }
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int Load(string email, string license, string plugin, ref string data)
        {
            string sqlConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select data from ce_data where email = @email and plugin = @plugin", connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@plugin", plugin));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = Convert.ToString(reader["data"]);
                    return 1;
                }

                return 0;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
    }
}

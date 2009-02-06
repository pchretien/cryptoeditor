using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CryptoEditorService
{
    class CryptoEditorServiceDaoMySql : ICryptoEditorServiceDaoInterface
    {
        public int LicenseExist(string email, string license)
        {
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);
            
            try
            {
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand("select count(*) from ce_user where email = ?email and license = ?license",
                                   connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?license", license));

                object count = command.ExecuteScalar();
                return Convert.ToInt32(count);
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
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            try
            {
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand("select count(*) from ce_user where email = ?email",
                                   connection);
                command.Parameters.Add(new MySqlParameter("?email", email));

                object count = command.ExecuteScalar();
                return Convert.ToInt32(count);
            }
            catch(Exception ex)
            {
                throw ex;
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
            MySqlDataReader reader = null;

            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            try
            {
                connection.Open();

                MySqlCommand command =
                    new MySqlCommand("select status, license, expiration from ce_user where email = ?email",
                    connection);
                command.Parameters.Add(new MySqlParameter("?email", email));

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
            MySqlDataReader reader = null;

            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select encrypted_license from ce_user where email = ?email", connection);
                command.Parameters.Add(new MySqlParameter("?email", email));

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
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select count(*) from ce_user where email = ?email and license = ?license", connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?license", license));

                object count = command.ExecuteScalar();
                if (Convert.ToInt32(count) == 0)
                    return Convert.ToInt32(count);

                command = new MySqlCommand("update ce_user set encrypted_license = ?encrypted_license where email = ?email and license = ?license", connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?license", license));
                command.Parameters.Add(new MySqlParameter("?encrypted_license", encryptedLicense));

                object updated = command.ExecuteNonQuery();
                return Convert.ToInt32(updated);
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
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);
            try
            {
                connection.Open();

                // Check if the data exist ...
                MySqlCommand command =
                    new MySqlCommand("select count(*) from ce_user where email = ?email and license = ?license",
                                   connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?license", license));

                object count = command.ExecuteScalar();
                if (Convert.ToInt32(count) == 0)
                    return Convert.ToInt32(count);

                command =
                    new MySqlCommand(
                        "update ce_user set status = ?status, expiration = ?expiration, lastupdate = ?lastupdate, encrypted_license = ?encrypted_license where email = ?email and license = ?license",
                        connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?license", license));
                command.Parameters.Add(new MySqlParameter("?encrypted_license", encryptedLicense));
                command.Parameters.Add(new MySqlParameter("?status", Convert.ToInt32(1)));
                command.Parameters.Add(new MySqlParameter("?expiration", DateTime.Now.AddMonths(3)));
                command.Parameters.Add(new MySqlParameter("?lastupdate", DateTime.Now));

                object updated = command.ExecuteNonQuery();
                if (Convert.ToInt32(updated) == 0)
                {
                    return Convert.ToInt32(updated);
                }

                command =
                    new MySqlCommand("select fullname, profile from ce_user where email = ?email and license = ?license",
                                   connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?license", license));

                MySqlDataReader reader = command.ExecuteReader();
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
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            try
            {
                connection.Open();

                // Generate the license key for that user
                license = Guid.NewGuid().ToString();

                MySqlCommand command = new MySqlCommand("insert into ce_user (email,profile,fullname,license,encrypted_license,status,expiration,lastupdate) values( ?email,?profile,?fullname,?license,?encrypted_license,?status,?expiration,?lastupdate)", connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?profile", profile));
                command.Parameters.Add(new MySqlParameter("?fullname", fullName));
                command.Parameters.Add(new MySqlParameter("?license", license));
                command.Parameters.Add(new MySqlParameter("?encrypted_license", ""));
                command.Parameters.Add(new MySqlParameter("?status", Convert.ToInt32(0)));
                command.Parameters.Add(new MySqlParameter("?expiration", DateTime.Now));
                command.Parameters.Add(new MySqlParameter("?lastupdate", DateTime.Now));

                object inserted = command.ExecuteNonQuery();
                return Convert.ToInt32(inserted);
            }
            catch(Exception ex)
            {
                throw ex;
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
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);

            try
            {
                connection.Open();

                // Check if the data exist ...
                MySqlCommand command = new MySqlCommand("select count(*) from ce_data where email = ?email and plugin = ?plugin", connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?plugin", plugin));

                object count = command.ExecuteScalar();
                if (Convert.ToInt32(count) == 0)
                {
                    command = new MySqlCommand("insert into ce_data (email,plugin,data,lastupdate) values( ?email,?plugin, ?data, ?lastupdate)", connection);
                    command.Parameters.Add(new MySqlParameter("?email", email));
                    command.Parameters.Add(new MySqlParameter("?plugin", plugin));
                    command.Parameters.Add(new MySqlParameter("?data", xml));
                    command.Parameters.Add(new MySqlParameter("?lastupdate", DateTime.Now));

                    int inserted = command.ExecuteNonQuery();
                    return inserted;
                }
                else
                {
                    command = new MySqlCommand("update ce_data set data = ?data, lastupdate = ?lastupdate where email = ?email and plugin = ?plugin", connection);
                    command.Parameters.Add(new MySqlParameter("?email", email));
                    command.Parameters.Add(new MySqlParameter("?plugin", plugin));
                    command.Parameters.Add(new MySqlParameter("?data", xml));
                    command.Parameters.Add(new MySqlParameter("?lastupdate", DateTime.Now));

                    object updated = command.ExecuteNonQuery();
                    return Convert.ToInt32(updated);
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
            string MySqlConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection connection = new MySqlConnection(MySqlConnectionString);
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select data from ce_data where email = ?email and plugin = ?plugin", connection);
                command.Parameters.Add(new MySqlParameter("?email", email));
                command.Parameters.Add(new MySqlParameter("?plugin", plugin));

                MySqlDataReader reader = command.ExecuteReader();

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

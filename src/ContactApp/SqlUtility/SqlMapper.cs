using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using System.Data.SqlClient;
using SqlUtility.Helper;

namespace SqlUtility
{
    public class SqlMapper : DataModel.Contract.IDataMapper<DataModel.Models.ContactDetailsModel, int>
    {
        readonly string _connectionString;
        public SqlMapper(string connectionstring)
        {
            _connectionString = connectionstring;

        }

        public bool Add(ContactDetailsModel obj)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.CommandText = "insert into ContactDetails(FirstName,LastName,Email,PhoneNumber,Status) " +
                        "VALUES('" + obj.FirstName + "','" + obj.LastName + "','" + obj.Email + "','" + obj.PhoneNumber + "','" + obj.Status + "')";
                    sqlcommand.Connection = conn;
                    conn.Open();
                    if (sqlcommand.ExecuteNonQuery() < 1)
                    {
                        conn.Close();
                        return false;
                    }
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }

        public bool Edit(ContactDetailsModel obj)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    ContactDetailsModel model = new ContactDetailsModel();
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.CommandText = "UPDATE ContactDetails SET FirstName='" + obj.FirstName + "'," +
                        "LastName='" + obj.LastName + "', " +
                        "Email='" + obj.Email + "', " +
                        "PhoneNumber='" + obj.PhoneNumber + "', " +
                        "Status='" + obj.Status + "'  where Id=" + obj.Id;
                    sqlcommand.Connection = conn;
                    conn.Open();
                    if (sqlcommand.ExecuteNonQuery() < 1)
                    {
                        conn.Close();
                        return false;
                    }
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }

        public List<ContactDetailsModel> GetAll()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    List<ContactDetailsModel> contactDetailslst = new List<ContactDetailsModel>();
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.CommandText = "SELECT * FROM ContactDetails";
                    sqlcommand.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = sqlcommand.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        ContactDetailsModel model = new ContactDetailsModel();
                        model.Id = reader.SafeGetInt("Id");
                        model.FirstName = reader.SafeGetString("FirstName");
                        model.LastName = reader.SafeGetString("LastName");
                        model.Email = reader.SafeGetString("Email");
                        model.PhoneNumber = reader.SafeGetString("PhoneNumber");
                       if( Enum.TryParse(reader.SafeGetString("Status"), out Status status))
                        model.Status = status;
                        contactDetailslst.Add(model);
                    }
                    conn.Close();

                    return contactDetailslst;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<ContactDetailsModel>();

                }
            }
        }

        public ContactDetailsModel GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    ContactDetailsModel model = new ContactDetailsModel();
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.CommandText = "SELECT * FROM ContactDetails where Id=" + id;
                    sqlcommand.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = sqlcommand.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        model.Id = reader.SafeGetInt("Id");
                        model.FirstName = reader.SafeGetString("FirstName");
                        model.LastName = reader.SafeGetString("LastName");
                        model.Email = reader.SafeGetString("Email");
                        model.PhoneNumber = reader.SafeGetString("PhoneNumber");
                        if (Enum.TryParse(reader.SafeGetString("Status"), out Status status))
                            model.Status = status;
                    }
                    conn.Close();
                    return model;
                }
                catch (Exception ex)
                {
                    return null;

                }
            }
        }

        public bool Remove(ContactDetailsModel obj)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    ContactDetailsModel model = new ContactDetailsModel();
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.CommandText = "DELETE FROM ContactDetails where Id=" + obj.Id;
                    sqlcommand.Connection = conn;
                    conn.Open();
                    if (sqlcommand.ExecuteNonQuery() < 1)
                    {
                        conn.Close();
                        return false;
                    }
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;

                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataModel.Models;

namespace SqlUtility.Helper
{
    public static class SqlHelper
    {
        public static bool CreateContactDetailsTable(string connectionString)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    List<ContactDetailsModel> contactDetailslst = new List<ContactDetailsModel>();
                   SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.CommandText = @"CREATE TABLE [dbo].[ContactDetails] (
                                            [Id]          INT IDENTITY(1, 1) NOT NULL,

                                        [FirstName]   NVARCHAR(50) NULL,
                                            [LastName] NVARCHAR(50) NULL,
                                            [Email] NVARCHAR(50) NULL,
                                            [PhoneNumber] NVARCHAR(50) NOT NULL,

                                           [Status]      NVARCHAR(50) NULL,
                                            PRIMARY KEY CLUSTERED([Id] ASC)
                                            );";
                    sqlcommand.Connection = conn;
                    conn.Open();
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

        public static string SafeGetString(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return null;
            }
        }

        public static int SafeGetInt(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetInt32(colIndex);
            }
            else
            {
                return 0;
            }
        }
    }
}

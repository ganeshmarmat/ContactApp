using DataModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LinqToXmlUtility.Helper
{
    class SchemaHelper
    {
        public static void Serialize(string filepath, object obj)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);

                formatter.Serialize(stream, obj);
                stream.Close();
            }catch(Exception ex)
            {
                throw;
            }
        }
        public static T Deserialize<T>(string filepath)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read);
                var objnew = (T)formatter.Deserialize(stream);
                stream.Close();
                return objnew;
            }
            catch
            {
                return default(T);
            }
            
        }
        /// <summary>
        /// this method method help convert raw data object into model object
        /// </summary>
        /// <param name="cntdata"> raw data for xml</param>
        /// <returns> model object</returns>
        public static ContactDetailsModel ConvertToModelClass(Contact cntdata)
        {
            Enum.TryParse(cntdata.Status, out Status statusobj);
            return new ContactDetailsModel()
            {
                Email = cntdata.Email,
                FirstName = cntdata.FirstName,
                LastName = cntdata.LastName,
                Id = cntdata.Id,
                Status = statusobj,
                PhoneNumber = cntdata.Phone
            };

        }
        public static Contact ConvertBackToSchemaClass(ContactDetailsModel cntdata)
        {
           
            return new Contact()
            {
                Email = cntdata.Email,
                FirstName = cntdata.FirstName,
                LastName = cntdata.LastName,
                Id = cntdata.Id,
                Status = cntdata.Status.ToString(),
                Phone = cntdata.PhoneNumber
            };

        }
    }
}

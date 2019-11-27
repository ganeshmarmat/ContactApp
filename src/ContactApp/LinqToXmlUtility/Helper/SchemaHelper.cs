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
        /// <summary>
        /// serialize object into Binary data
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="obj"></param>
        public static void Serialize(string filepath, object obj)
        {
            try
            {
                //we dont want to readable file Binaryformatter suitable for it
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(stream, obj);
                stream.Close();
            }catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserialize object from binary data to orignal model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string filepath)
        {
            Stream stream=null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read);
                var objnew = (T)formatter.Deserialize(stream);
                stream.Close();
                return objnew;
            }
            catch
            {
                stream.Close();
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

        /// <summary>
        /// Convert object into origanal model
        /// </summary>
        /// <param name="cntdata"></param>
        /// <returns></returns>
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

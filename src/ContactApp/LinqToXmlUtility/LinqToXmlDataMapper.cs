using System;
using System.Collections.Generic;
using DataModel.Contract;
using DataModel.Models;

namespace LinqToXmlUtility
{
    public class LinqToXmlDataMapper : IDataMapper<DataModel.Models.ContactDetailsModel, int>
    {
        readonly string _filepath;
        Contacts _contacts;
        public LinqToXmlDataMapper(string filepath)
        {

            string curdir = new System.IO.FileInfo(filepath).DirectoryName;
            curdir = System.IO.Path.Combine(curdir, "data");
            if (!System.IO.Directory.Exists(curdir))
                System.IO.Directory.CreateDirectory(curdir);
            _filepath = System.IO.Path.Combine(curdir, new System.IO.FileInfo(filepath).Name);
            if(System.IO.File.Exists(_filepath))
            _contacts = Helper.SchemaHelper.Deserialize<Contacts>(_filepath);
        }
        public bool Add(ContactDetailsModel obj)
        {
            try
            {
                var schemaclassobj = Helper.SchemaHelper.ConvertBackToSchemaClass(obj);
                if (_contacts == null)
                    _contacts = new Contacts() { Contact = new List<Contact>() };
                _contacts.Contact.Add(schemaclassobj);
                Helper.SchemaHelper.Serialize(_filepath, _contacts);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(ContactDetailsModel obj1)
        {
            try
            {
                var currentobj = _contacts.Contact.FindIndex(x => x.Id == obj1.Id);
                var newobj = Helper.SchemaHelper.ConvertBackToSchemaClass(obj1);
                _contacts.Contact[currentobj] = newobj;
                Helper.SchemaHelper.Serialize(_filepath, _contacts);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<ContactDetailsModel> GetAll()
        {
            try
            {
                List<ContactDetailsModel> contactDetailslist = new List<ContactDetailsModel>();
                foreach (var item in _contacts.Contact)
                {
                    contactDetailslist.Add(Helper.SchemaHelper.ConvertToModelClass(item));
                }
                return contactDetailslist;
            }
            catch
            {
                return new List<ContactDetailsModel>();
            }
        }

        public ContactDetailsModel GetById(int id)
        {
            try
            {
                return Helper.SchemaHelper.ConvertToModelClass(_contacts.Contact.Find(x => x.Id == id));
            }
            catch
            {
                return new ContactDetailsModel();
            }
        }

        public bool Remove(ContactDetailsModel obj)
        {
            try
            {
                _contacts.Contact.Remove(_contacts.Contact.Find(x => x.Id == obj.Id));
                Helper.SchemaHelper.Serialize(_filepath, _contacts);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

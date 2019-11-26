using DataModel.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactApp.App_Start
{
    public class ObjectRegistration
    {
        private static IDataMapper<DataModel.Models.ContactDetailsModel, int> _contactDataSource;
        public static IDataMapper<DataModel.Models.ContactDetailsModel, int> ContactDataSource
        {
            get
            {
                if (_contactDataSource == null)
                    _contactDataSource = ObjectFactory.Factory.CreateInstance(ObjectFactory.InstanceType.LinqToXml);
                return _contactDataSource;
            }
        }

    }
}
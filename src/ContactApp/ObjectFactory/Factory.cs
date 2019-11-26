using DataModel.Contract;
using LinqToXmlUtility;
using System;

namespace ObjectFactory
{
    public class Factory
    {
        private static IDataMapper<DataModel.Models.ContactDetailsModel, int> GetLinqToXml()
        {
            return new LinqToXmlDataMapper("..\\..\\..\\Sample.xml");
        }
        private static IDataMapper<DataModel.Models.ContactDetailsModel, int> GetSqlUtility()
        {
            return new SqlUtility.SqlMapper(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContactAppDB;Integrated Security=True");
        }
        public static IDataMapper<DataModel.Models.ContactDetailsModel, int> CreateInstance(InstanceType instanceType)
        {
            switch(instanceType)
            {
                case InstanceType.LinqtoSql:
                    
                    break;
                case InstanceType.LinqToXml:
                    return GetLinqToXml();
                    break;
                case InstanceType.SqlUtility:
                    return GetSqlUtility();
                    break;
            }

            return null;
        }

    }
    public enum InstanceType
    {
        LinqToXml,
        SqlUtility,
        LinqtoSql
    }
}

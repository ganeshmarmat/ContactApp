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

using DataModel.Contract;
using ObjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContactApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDataMapper<DataModel.Models.ContactDetailsModel, int> DataSource; 
        protected void Application_Start()
        {
            DataSource= Factory.CreateInstance(InstanceType.SqlUtility);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

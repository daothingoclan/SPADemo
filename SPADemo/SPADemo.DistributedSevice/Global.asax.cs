using SPADemo.Data.DAL;
using SPADemo.DistributedSevice.App_Start;
using SPADemo.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SPADemo.DistributedSevice
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new AnimalInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Run();
            new AutoMapperConfiguration();
        }
    }
}

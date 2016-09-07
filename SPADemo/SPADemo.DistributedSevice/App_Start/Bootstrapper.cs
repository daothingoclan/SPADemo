using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using SPADemo.Data.Infrastructure;
using SPADemo.Domain;
using SPADemo.Service;
using System.Reflection;
using System.Web.Http;

namespace SPADemo.DistributedSevice.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Dbfactory
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repository
            builder.RegisterType<Repository>().As<IRepository>().InstancePerRequest();

            // Service
            builder.RegisterAssemblyTypes(typeof(AnimalService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            IContainer container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}
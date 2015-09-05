using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using HealthSmartCity.Infrastructure;

namespace HealthSmartCity.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureDependencies();
        }

        private void ConfigureDependencies()
        {
            var builder = new ContainerBuilder();
            IContainer container = builder.Build();
            //builder.RegisterType<DataContext>().As<IDataContext>();

            IDependencyResolver dependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(dependencyResolver);
        }
    }
}

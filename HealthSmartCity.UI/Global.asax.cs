using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

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
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).AsImplementedInterfaces().InstancePerRequest();
            IContainer container = containerBuilder.Build();

            IDependencyResolver dependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(dependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = new Infrastructure.AutofacDependencyResolver(container);
        }
    }
}

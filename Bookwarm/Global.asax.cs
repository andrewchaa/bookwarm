using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bookwarm.Infrastructure;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Bookwarm
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterWindsorContainer();

        }

        private void RegisterWindsorContainer()
        {

            _container = new WindsorContainer().Install(FromAssembly.This());
            ControllerBuilder.Current.SetControllerFactory(new WindsorMvcControllerFactory(_container.Kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorHttpDependencyResolver(_container.Kernel);
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}
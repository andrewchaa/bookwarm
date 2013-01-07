using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using Bookwarm.Controllers;
using Bookwarm.Infrastructure;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bookwarm.Installers
{
    public class ApiControllerInstaller : IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<ITypedFactoryComponentSelector>().ImplementedBy<WebApiTypedFactoryComponentSelector>());
            container.Register(Component.For<IDependencyScope>().AsFactory(f => f.SelectedWith<WebApiTypedFactoryComponentSelector>()).LifestylePerWebRequest());

            container.Register(
                Classes.FromAssemblyContaining<PageController>().BasedOn<IHttpController>().LifestyleTransient());
        }
    }
}
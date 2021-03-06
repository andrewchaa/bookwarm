﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookwarm.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bookwarm.Installers
{
    public class RepositoryInstaller : IWindsorInstaller 
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IReadingRepository, ReadingRepository>());
        }
    }
}
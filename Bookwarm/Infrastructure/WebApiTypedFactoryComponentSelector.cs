using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;

namespace Bookwarm.Infrastructure
{
    public class WebApiTypedFactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            if (method.Name == "GetService" || method.Name == "GetServices")
            {
                return (arguments[0] as Type).FullName;
            }
            return base.GetComponentName(method, arguments);
        }

        protected override Type GetComponentType(MethodInfo method, object[] arguments)
        {
            if (method.Name == "GetService" || method.Name == "GetSErvices")
            {
                return arguments[0] as Type;
            }
            return base.GetComponentType(method, arguments);
        }
    }
}
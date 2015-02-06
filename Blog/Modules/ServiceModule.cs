using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Blog.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Blog")).Where(
                t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
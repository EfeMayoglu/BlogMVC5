using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Blog.DatabaseContext;
using Blog.Models;

namespace Blog.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(BlogEntriesDbContext)).As(typeof(IDbContext)).InstancePerLifetimeScope();
        }
    }
}
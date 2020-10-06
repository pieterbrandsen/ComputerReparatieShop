using Autofac;
using Autofac.Integration.Mvc;
using ComputerRepairShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepairShop.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            // Extension method of the Container builder accepting undefined amount of Reflection.Assembly specifications to apply.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //  Whenever swapping from restaurant data to a other source you can alter the type here.
            builder.RegisterType<SqlComputerRepairShopData>().As<IComputerRepairShopData>().InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            // Build the mapped IoC container:
            var container = builder.Build();
            // Pass the container to the dependency resolver, a class defined by the MVC5
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
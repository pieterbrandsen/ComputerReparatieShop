using ComputerReperatieShop.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

namespace ReparatieShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerConfig.RegisterContainer();
<<<<<<< HEAD:ComputerReparatieShop/ComputerReparatieShop.Web/Global.asax.cs

=======
>>>>>>> 692eb3a2a11563bc44a11433decd57f8ff6a5edd:ComputerReperatieShop/Global.asax.cs
        }
    }
}

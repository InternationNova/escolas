using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Scholas
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "escolas", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "escolas", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
               "ope", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new { controller = "ope", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );
            routes.MapRoute(
              "gastos", // Route name
              "{controller}/{action}/{id}", // URL with parameters
              new { controller = "gastos", action = "Index", id = UrlParameter.Optional } // Parameter defaults
          );
            routes.MapRoute(
             "fornecedores", // Route name
             "{controller}/{action}/{id}", // URL with parameters
             new { controller = "fornecedores", action = "Index", id = UrlParameter.Optional } // Parameter defaults
         );
            routes.MapRoute(
             "materiaPrima", // Route name
             "{controller}/{action}/{id}", // URL with parameters
             new { controller = "materiaPrima", action = "Index", id = UrlParameter.Optional } // Parameter defaults
         );
            routes.MapRoute(
             "transportadora", // Route name
             "{controller}/{action}/{id}", // URL with parameters
             new { controller = "transportadora", action = "Index", id = UrlParameter.Optional } // Parameter defaults
         );
            routes.MapRoute(
            "categoriaMateriaPrimas", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "categoriaMateriaPrimas", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
            routes.MapRoute(
      "categoriaSubProdutos", // Route name
      "{controller}/{action}/{id}", // URL with parameters
      new { controller = "categoriaSubProdutos", action = "Index", id = UrlParameter.Optional } // Parameter defaults
  );
            routes.MapRoute(
      "consumos", // Route name
      "{controller}/{action}/{id}", // URL with parameters
      new { controller = "consumos", action = "Index", id = UrlParameter.Optional } // Parameter defaults
  );
            routes.MapRoute(
     "perda", // Route name
     "{controller}/{action}/{id}", // URL with parameters
     new { controller = "perda", action = "Index", id = UrlParameter.Optional } // Parameter defaults
 );

            routes.MapRoute(
            "report", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "report", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
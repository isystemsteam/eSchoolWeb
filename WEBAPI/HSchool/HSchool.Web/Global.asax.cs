using HSchool.Logging;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bootstrap.AutoMapper;
using Microsoft.AspNet.Identity;
using HSchool.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HSchool.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            LogHelper.Info(string.Format("WebApiApplication.OnApplicationStarted - Begin"));
            AreaRegistration.RegisterAllAreas();            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
            Bootstrap.Bootstrapper.With.AutoMapper().Start();

            LogHelper.Info(string.Format("WebApiApplication.OnApplicationStarted - End"));
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly(),
                Assembly
                    .Load("HSchool.Business"),
                Assembly
                    .Load("HSchool.Data"),
                Assembly
                    .Load("HSchool.CompositionRoot"), Assembly.Load("HSchool.Common"));

            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf();

            return kernel;
        }
    }
}

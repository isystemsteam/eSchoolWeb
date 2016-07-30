using HSchool.Logging;
using HSchool.WebApi.AppStart;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bootstrap.AutoMapper;
using System.Data.Entity;
using HSchool.Authentication;
using Microsoft.AspNet.Identity;
using HSchool.WebApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HSchool.WebApi
{
    public class WebApiApplication : NinjectHttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    GlobalConfiguration.Configure(WebApiConfig.Register);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            LogHelper.Info(string.Format("WebApiApplication.OnApplicationStarted - Begin"));
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
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

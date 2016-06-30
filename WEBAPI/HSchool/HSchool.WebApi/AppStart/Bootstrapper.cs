using HSchool.CompositionRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HSchool.WebApi.AppStart
{
    public static class BootstrapperStart
    {
        public static void Register()
        {
            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(DependencyMapper.BuildUnityContainer());
        }
    }
}
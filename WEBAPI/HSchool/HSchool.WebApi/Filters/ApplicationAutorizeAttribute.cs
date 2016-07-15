using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSchool.WebApi.Filters
{
    public class ApplicationAutorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userGroup = "";
                LogHelper.Info(string.Format("CustomAutorization - Begin. UserGroup:{0} and UserName:{1}", userGroup, filterContext.HttpContext.User.Identity.Name));
                var result = filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.User.IsInRole(userGroup);
                LogHelper.Info(string.Format("CustomAutorization - Roles validation, UserName:{0} and Result:{1}", filterContext.HttpContext.User.Identity.Name, result));
                if (!result)
                {
                    filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Mvc.Filters;


namespace HSchool.WebApi.Filters
{
    public class CustomAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext context)
        {
            if (context.HttpContext != null && context.HttpContext.User != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                // do nothing
            }
            else
            {
                context.Result = new HttpUnauthorizedResult(); // mark unauthorized
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                context.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Account"},
                        {"action", "Login"},
                        {"returnUrl", context.HttpContext.Request.RawUrl}
                    });
            }
        }
    }
}
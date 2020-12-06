using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.News.Infrastructures
{
    public class AllowAdminAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Go to login page if cookies is finished
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("admin"))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX requests, we're overriding the returned JSON result with a simple string,
                    // indicating to the calling JavaScript code that a redirect should be performed.
                    filterContext.Result = new JsonResult { Data = "Logon" };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                        { "Controller", "Account" },
                        { "Action", "Login" }
                    });
                }
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
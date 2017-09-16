using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["userInfo"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
using System.Web.Mvc;
using System.Web.Routing;

namespace News.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["ACCOUNT_SESSION"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "../Login", action = "Index"}));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
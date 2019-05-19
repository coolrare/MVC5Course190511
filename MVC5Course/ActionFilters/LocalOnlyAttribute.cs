using MVC5Course.Models;
using MVC5Course.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MVC5Course.ActionFilters
{
    public class LocalOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
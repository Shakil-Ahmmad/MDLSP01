using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mass_Data_Education.Models
{
    public static class IsActiveLink
    {
        public static string IsActive(this HtmlHelper html, string controllers = "", string actions = "", string param = "", string cssClass = "active")
        {
            ViewContext viewContext = html.ViewContext;
            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

            if (isChildAction)
                viewContext = html.ViewContext.ParentActionViewContext;

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();
            string url = HttpContext.Current.Request.Url.Query;
            bool active = false;

            if (param != "" && url.Contains(param))
                active = true;

            if (string.IsNullOrWhiteSpace(actions))
                actions = currentAction;

            if (string.IsNullOrWhiteSpace(controllers))
                controllers = currentController;

            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

            if (param != "" && active && acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController))
                return cssClass;
            else if (param != "" && !active && acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController))
                return string.Empty;
            else
                return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ? cssClass : string.Empty;
        }
    }
}
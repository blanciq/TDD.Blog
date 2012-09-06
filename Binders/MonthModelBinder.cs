using System.Web.Mvc;
using TDD.Blog.Models;

namespace TDD.Blog.Binders
{
    public class MonthModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var month = controllerContext.RequestContext.RouteData.Values["month"] as string;
            switch (month)
            {
                case "january":
                    return Month.January;
                case "february":
                    return Month.February;
            }
            return null;
        }
    }
}
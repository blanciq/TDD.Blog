using System.Web;
using System.Web.Mvc;

namespace TDD.Blog.Controllers
{
    public class BaseController : Controller
    {
        public HttpContextBase Context { get; set; }

        protected static void NotFound()
        {
            throw new HttpException(404, "Not Found");
        }
    }
}
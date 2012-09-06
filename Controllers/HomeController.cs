using System;
using System.Web;
using System.Web.Mvc;
using TDD.Blog.Infrastructure;
using TDD.Blog.Repositories;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostRepository _postRepository;
        private readonly AutomapperWrapper _mapper;

        public HomeController(IPostRepository postRepository, AutomapperWrapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var posts = _postRepository.GetAllPost();

            var model = _mapper.Map<HomePageViewModel>(posts);

            if (Session["visits"] != null)
            {
                Session["visits"] = (int)Session["visits"] + 1;
            }
            else
            {
                Session["visits"] = 1;
            }
            model.Visits = (int)Session["visits"];


            return View(model);
        }

        public ActionResult Exception()
        {
            throw new Exception();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}

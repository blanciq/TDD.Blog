using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TDD.Blog.Binders;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;
using TDD.Blog.Repositories;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostRepository _repository;
        private readonly AutomapperWrapper _mapper;

        public PostController(IPostRepository repository, AutomapperWrapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Details(long id)
        {
            var post = _repository.Get(id);
            if (post == null)
                NotFound();
            return View(_mapper.Map<PostViewModel>(post));
        }

        public ActionResult Month([ModelBinder(typeof(MonthModelBinder))]Month month)
        {
            return View(month);
        }

        [ChildActionOnly]
        public ActionResult Comments(long postid)
        {
            var comments = _repository.GetCommentsFor(postid);
            return PartialView(_mapper.Map<CommentsViewModel>(comments));
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel model)
        {
            _repository.AddComment(_mapper.Map<Comment>(model));
            var comments = _repository.GetCommentsFor(model.PostId);
            return PartialView("Comments", _mapper.Map<CommentsViewModel>(comments));
        }
    }
}
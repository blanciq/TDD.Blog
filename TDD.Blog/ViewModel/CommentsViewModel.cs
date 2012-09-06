using System.Collections.Generic;

namespace TDD.Blog.ViewModel
{
    public class CommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
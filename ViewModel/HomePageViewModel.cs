using System.Collections.Generic;

namespace TDD.Blog.ViewModel
{
    public class HomePageViewModel
    {
        public int Visits { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
using System.Collections.Generic;
using TDD.Blog.Models;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPost();
        Post Get(long id);
        IEnumerable<Comment> GetCommentsFor(long postid);
        void AddComment(Comment comment);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using NUnit.Framework;
using TDD.Blog.Infrastructure;
using TDD.Blog.Models;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Tests
{
    [TestFixture]
    public class MapperTests
    {
        [TestFixtureSetUp]
        public void Configure()
        {
            AutomapperConfiguration.Configure();
        }

        [Test]
        public void CheckAutomapperConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void CanMapListOfCommentsToCommentsViewModel()
        {
            var comments = new List<Comment> {new Comment { Author = "bq"}};

            var result = Mapper.Map<CommentsViewModel>(comments);

            Assert.AreEqual("bq", result.Comments.Single().Author);
        }

        [Test]
        public void CanMapCommentViewModelToCommentEntity()
        {
            var comment = Mapper.Map<Comment>(new CommentViewModel());

            Assert.IsNotNull(comment);
        }

        [Test]
        public void CanMapPostEntityToPostViewModel()
        {
            var result = Mapper.Map<PostViewModel>(new Post {PostId = 1});

            Assert.AreEqual(1, result.Id);
        }
    }
}

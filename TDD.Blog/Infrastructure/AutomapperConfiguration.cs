using System.Collections.Generic;
using AutoMapper;
using TDD.Blog.Models;
using TDD.Blog.ViewModel;

namespace TDD.Blog.Infrastructure
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<List<Post>, HomePageViewModel>()
                .ForMember(x => x.Posts, cfg => cfg.MapFrom(x => x))
                .ForMember(x => x.Visits, cfg => cfg.Ignore());

            Mapper.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Id, cfg => cfg.MapFrom(x => x.PostId));

            Mapper.CreateMap<List<Comment>, CommentsViewModel>()
                .ForMember(x => x.Comments, cfg => cfg.MapFrom(x => x));

            Mapper.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.PostId, cfg => cfg.Ignore());

            Mapper.CreateMap<CommentViewModel, Comment>()
                .ForMember(x => x.CommentId, cfg => cfg.Ignore())
                .ForMember(x => x.Post, cfg => cfg.Ignore());
        }

    }
}
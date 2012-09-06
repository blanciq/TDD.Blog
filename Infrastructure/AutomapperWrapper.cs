using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TDD.Blog.Infrastructure
{
    public class AutomapperWrapper
    {
        public TDestination Map<TSource, TDestination>(TSource obj)
        {
            return Mapper.Map<TSource, TDestination>(obj);
        }

        public TDestination Map<TDestination>(object obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Cloud.AutoMapper
{
    public static class AutoMapperHelper
    {
        public static IServiceProvider serviceProvider;

        //public static void UseStateAutoMapper(this IApplicationBuilder applicationBuilder)
        //{
        //    serviceProvider = applicationBuilder.ApplicationServices;
        //}

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            return mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TDestination>(this object source)
        {
            if(source==default)
                return default;
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            return mapper.Map<TDestination>(source);
        }

        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            return mapper.Map<List<TDestination>>(source);
        }

        public static IEnumerable<TDestination> MapToIEnumerable<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            var mapper = serviceProvider.GetRequiredService<IMapper>();
            return mapper.Map<IEnumerable<TDestination>>(source);
        }

    }
}

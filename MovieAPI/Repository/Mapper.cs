
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieBL;
using MovieDal.Models;
using AutoMapper;

namespace MovieAPI.Repository
{
   
        public class ModelMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public ModelMapper()
        {
            Mapper.CreateMap<MovieItem, MovieItemViewModel>();
            
                    Mapper.CreateMap<MovieItem, MovieItemDetailsViewModel>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
   
         
            }
}
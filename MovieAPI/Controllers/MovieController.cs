using AutoMapper;
using log4net;
using MovieAPI.Models;
using MovieAPI.Repository;
using MovieBL;
using MovieDal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieAPI.Controllers
{
    [RoutePrefix("Api/Movie")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovieController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]

        public IHttpActionResult GetMovieData()
        {
            try
            {
                log.Info("start GetMovieData");
                List<MovieItemViewModel> movies = new List<MovieItemViewModel>();
                ModelMapper<MovieItem, MovieItemViewModel> mapObj = new ModelMapper<MovieItem, MovieItemViewModel>();
                List<MovieItem> movieList = BL.GetMovieData();
                foreach (var item in movieList)
                {
                    movies.Add(mapObj.Translate(item));
                }
                log.Info("end GetMovieData response "+movies.ToString());
                return Ok(movies.AsEnumerable());
            }
            catch (HttpRequestException httpRequestException)
            {
                log.Error(" GetMovieData error:" + httpRequestException.Message);
                return BadRequest($"Error getting movie data {httpRequestException.Message}");
            }



            return null;
        }
        [HttpGet]
        [Route("getMovieByID/{id}")]
        public IHttpActionResult getMovieByID(int id)
        {
            try
            {
                log.Info("start getMovieByID id "+id.ToString());
                ModelMapper<MovieItem, MovieItemDetailsViewModel> mapObj = new ModelMapper<MovieItem, MovieItemDetailsViewModel>();
                // return Ok(
                MovieItem mi = BL.getMovieByID(id);
                log.Info("end getMovieByID response " + mi.ToString());
                return Ok(mapObj.Translate(mi));
            }
            catch (HttpRequestException httpRequestException)
            {
                log.Error(" getMovieByID error:" + httpRequestException.Message);
                return BadRequest($"Error getting movie data {httpRequestException.Message}");
            }



            return null;
        }

    }

}


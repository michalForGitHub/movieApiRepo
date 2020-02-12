using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MovieDal.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MovieDal
{
    public static class Dal
    {
        public static List<MovieItem> GetData()
        {
            var cache = HttpContext.Current.Cache;
            List<MovieItem> movies;
            if (cache != null)
            {
                movies = new List<MovieItem>();
                if (cache["allMovies"] == null)
                {
                    Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                    String Root = Directory.GetCurrentDirectory();
                    int index = Root.LastIndexOf("\\");
                    Root = Root.Substring(0, index) + "\\MovieDal\\Data\\MoviesData.json";
   
                    string allData = System.IO.File.ReadAllText(Root);
                    var movieData = JsonConvert.DeserializeObject<List<MovieItem>>(allData);
                    cache["allMovies"] = movieData;
                    return movieData;
                }
                else
                {
                    movies = cache["allMovies"] as List<MovieItem>;
                    return movies;
                }

            }
            return null;
        }
        public static MovieItem getMovieByID(int id)
        {
            var cache = HttpContext.Current.Cache;
            List<MovieItem> movies;
            if (cache != null)
            {
                movies = new List<MovieItem>();
                if (cache["allMovies"] == null)
                {
                    Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                    String Root = Directory.GetCurrentDirectory();
                    int index = Root.LastIndexOf("\\");
                    Root = Root.Substring(0, index) + "\\MovieDal\\Data\\MoviesData.json";

                    string allData = System.IO.File.ReadAllText(Root);
                    var movieData = JsonConvert.DeserializeObject<List<MovieItem>>(allData);
                    cache["allMovies"] = movieData;
                    return movies.Where(i => i.ID == id).FirstOrDefault();
                }
                else
                {
                    movies = cache["allMovies"] as List<MovieItem>;
                   return  movies.Where(i => i.ID == id).FirstOrDefault();
                  
                }

            }
            return null;
        }
    }
}

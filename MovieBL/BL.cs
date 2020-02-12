
using MovieDal;
using MovieDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBL
{
    public static class BL
    {
        public static List<MovieItem> GetMovieData()
        {
          return Dal.GetData();
        }
        public static MovieItem getMovieByID(int id)
        {
            return Dal.getMovieByID(id);
        }
    }
}

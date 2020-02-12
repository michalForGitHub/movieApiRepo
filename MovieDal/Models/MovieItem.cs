using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDal.Models
{
    public class MovieItem
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Season { get; set; }
        public int Views { get; set; }

    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Models
{
    public class MovieItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Season { get; set; }
        public int Views { get; set; }

    }
}
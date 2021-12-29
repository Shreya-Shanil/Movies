using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Models
{
    public class MoviesVO
    {
        public int srno { get; set; }
        public string mname { get; set; }
        public int years { get; set; }
        public string actor { get; set; }
        public string actress { get; set; }
        public string dname { get; set; }
    }

    public class MoviesSearch
    {
        public List<MoviesVO> Movies { get; set; }
        public string Search { get; set; }
    }
}

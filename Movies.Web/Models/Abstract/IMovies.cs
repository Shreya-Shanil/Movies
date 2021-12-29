using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Models.Abstract
{
    public interface IMovies
    {
        public List<MoviesVO> Get(int intSrNo);
        public List<MoviesVO> GetByActorName(string strActorName);
        public int Set(MoviesVO moviesVO);
    }
}

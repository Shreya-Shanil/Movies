using Microsoft.AspNetCore.Mvc;
using Movies.Web.Models;
using Movies.Web.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovies movies;
        private MoviesVO moviesVO;
        private List<MoviesVO> MoviesVOs;
        private MoviesSearch moviesSearch;
        public MoviesController(IMovies movies)
        {
            this.movies = movies;
        }
        public IActionResult Index()
        {
            moviesSearch = new MoviesSearch();
            MoviesVOs = movies.Get(0);
            moviesSearch.Movies = MoviesVOs;
            moviesSearch.Search = string.Empty;
            return View(moviesSearch);
        }

        [HttpPost]
        public IActionResult Set(MoviesVO objMovies)
        {
            movies.Set(objMovies);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Get(int intSrNo)
        {
            if (intSrNo>0)
            {
                MoviesVOs = movies.Get(intSrNo);
            }
            if (MoviesVOs == null)
            {
                MoviesVOs = new List<MoviesVO> {
                new MoviesVO()
                };
            }
            return View(MoviesVOs[0]);
        }

        [HttpGet]
        public IActionResult GetByActorName(string strActorName)
        {
            moviesSearch = new MoviesSearch();
            MoviesVOs = movies.GetByActorName(strActorName);
            if (MoviesVOs == null)
            {
                MoviesVOs = new List<MoviesVO>();
            }
            moviesSearch.Movies = MoviesVOs;
            moviesSearch.Search = strActorName;
            return View("Index", moviesSearch);
        }
    }
}

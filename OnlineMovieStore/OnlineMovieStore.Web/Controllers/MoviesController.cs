using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Models;

namespace OnlineMovieStore.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService ?? throw new ArgumentNullException(nameof(moviesService));
        }

        public IActionResult Index(AllMoviesViewModel model)
        {
            IEnumerable<Movie> movies;
            AllMoviesViewModel newModel;
            if (model.SearchText == "")
            {
                movies = this.moviesService.ListMovies(model.Page-1, null);
                newModel = new AllMoviesViewModel(movies);
                model.TotalPages = (int)Math.Ceiling(this.moviesService.Total() / (double)1);
            }
            else
            {
                movies = this.moviesService.ListMovies(model.Page-1, model.SearchText);
                newModel = new AllMoviesViewModel(movies);
                model.TotalPages = (int)Math.Ceiling(this.moviesService.TotalContainingText(model.SearchText) / (double)1);
            }

      
            
            return View(newModel);
        }

        public IActionResult Details(string title)
        {
            var movie = this.moviesService.ListMoviesByTitle(title);

            return View(new MoviesViewModel(movie));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Areas.Administration.Models;
using OnlineMovieStore.Web.Data;

namespace OnlineMovieStore.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ManageMoviesController : Controller
    {
        private ApplicationDbContext context;
        private IMoviesService movieService;

        public ManageMoviesController(ApplicationDbContext ctxt, IMoviesService movie)
        {
            this.context = ctxt;
            this.movieService = movie;
        }

        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            List<Actor> actors = this.context.Actors.ToList();
            List<Genre> genres = this.context.Genres.ToList();

            AddMovieViewModel vM = new AddMovieViewModel(actors, genres);

            return View(vM);
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieViewModel vm)
        {

            List<Genre> genres = new List<Genre>();

            foreach (var g in vm.Genres)
            {
                if (g.IsChecked == true)
                {
                    genres.Add(new Genre { Id = g.Id, Name = g.Name });
                }
            }

            this.movieService.AddMovie(vm.ImageURL, vm.Title, vm.Year, genres, int.Parse(vm.ActorId), vm.Price);

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Message sent!", MediaTypeNames.Text.Plain);
        }
    }
}
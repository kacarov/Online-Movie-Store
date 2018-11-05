using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Web.Areas.Administration.Models;
using OnlineMovieStore.Web.Data;

namespace OnlineMovieStore.Web.Areas.Admin.Controllers
{
    [Area("Administration")]
    public class AdminController : Controller
    {
        private ApplicationDbContext context;

        public AdminController(ApplicationDbContext ctxt)
        {
            this.context = ctxt;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult Users()
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
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Message sent!", MediaTypeNames.Text.Plain);
        }
    }
}
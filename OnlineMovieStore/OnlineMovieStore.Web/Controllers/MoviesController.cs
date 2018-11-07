﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string title)
        {
            var movie = this.moviesService.ListMoviesByTitle(title);

            return View(new MoviesViewModel(movie));
        }
    }
}
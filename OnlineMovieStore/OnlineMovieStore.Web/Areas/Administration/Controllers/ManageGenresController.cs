using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMovieStore.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ManageGenresController : Controller
    {
        public IActionResult Genres()
        {
            return View();
        }

        public IActionResult AddGenre()
        {
            return View();
        }
    }
}
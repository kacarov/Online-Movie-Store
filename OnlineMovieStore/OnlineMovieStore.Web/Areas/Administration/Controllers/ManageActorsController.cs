using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMovieStore.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ManageActorsController : Controller
    {
        public IActionResult Actors()
        {
            return View();
        }

        public IActionResult AddActor()
        {
            return View();
        }
    }
}
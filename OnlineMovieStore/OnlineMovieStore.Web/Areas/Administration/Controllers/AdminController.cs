using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMovieStore.Web.Areas.Admin.Controllers
{
    [Area("Administration")]
    public class AdminController : Controller
    {
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
    }
}
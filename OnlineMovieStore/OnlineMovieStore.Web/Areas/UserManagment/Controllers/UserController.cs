using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Areas.UserManagment.Models;

namespace OnlineMovieStore.Web.Areas.UserManagment.Controllers
{
    [Area("UserManagment")]
    [Route("User/[controller]")]
    public class UserController : Controller
    {
        private IUsersService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUsersService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            var userOrders = this.userService.Orders(this.userManager.GetUserId(User));
            var viewModel = new UserMoviesViewModel(userOrders);

            return View(viewModel);
        }

        [Route("[action]/{id}")]
        public IActionResult MyMovies(string id)
        {
            var content = this.userService.Orders(id);
            var viewModel = new UserMoviesViewModel(content);

            return this.View(viewModel);
        }

        // [Authorize]
        // [ValidateAntiForgeryToken]
        public IActionResult RequestMovie()
        {
            return View();
        }

        // [Authorize]
        //  [ValidateAntiForgeryToken]
        public IActionResult Help()
        {
            return View();
        }

        // [Authorize]
        // [ValidateAntiForgeryToken]
        // [HttpPost]
        public IActionResult UserDeposit(string id)
        {
            return PartialView("_Deposit", new UserDepositViewModel(userService.GetUser(id)));
        }
    }
}
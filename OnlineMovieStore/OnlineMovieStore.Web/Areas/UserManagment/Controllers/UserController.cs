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
        private readonly IUsersService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IUsersService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]/{id}")]
        public IActionResult MyMovies(string id)
        {
            var content = this.userService.Orders(id);
            var viewModel = new UserMoviesViewModel(content);

            return this.View(viewModel);
        }

        [Route("[action]")]
        public IActionResult OrdersDetails()
        {
            var userOrders = this.userService.OrdersDetails(this.userManager.GetUserId(User));

            var viewModel = new UserOrdersViewModel(userOrders);

            return View(viewModel);
        }

        //[Authorize]
        // [ValidateAntiForgeryToken]
        // [HttpPost]
        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Deposit(string id)
        {
            var user = this.userService.GetUser(id);

            var userModel = new UserDepositViewModel(user);

            return View(userModel);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Deposit(UserDepositViewModel model)
        {
            var user = this.userService.AddToVallet(model.DepositSum, this.userManager.GetUserId(User));
            var userModel = new UserDepositViewModel(user);

            return View(userModel);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult AccountSettings()
        {
            var user = this.userService.GetUser(this.userManager.GetUserId(User));

            var userModel = new UserViewModel(user);

            return View(userModel);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AccountSettings(UserViewModel model)
        {
            //Update user settings
            var user = this.userService.UpdateAccountDetails(model.Username, model.Email, model.PhoneNumber, this.userManager.GetUserId(User));

            //Pass model
            var userModel = new UserViewModel(user);

            this.signInManager.SignOutAsync();

            return RedirectToAction("Logout", "Account", new { area = "Identity" });
        }

        // [Authorize]
        // [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult RequestMovie()
        {
            return View();
        }

        // [Authorize]
        //  [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Help()
        {
            return View();
        }
    }
}
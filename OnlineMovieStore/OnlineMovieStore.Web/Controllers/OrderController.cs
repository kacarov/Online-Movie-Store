using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Models;

namespace OnlineMovieStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private IUsersService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IUsersService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult UserOrders(string id)
        {
            var content = this.userService.Orders(id);
            var viewModel = new OrderViewModel(content);

            return this.View(viewModel);
        }
    }
}
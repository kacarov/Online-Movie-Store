using Microsoft.AspNetCore.Mvc;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Models;

namespace OnlineMovieStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private IUsersService userService;

        public OrderController(IUsersService userService)
        {
            this.userService = userService;
        }

        public IActionResult UserOrders()
        {
            var content = this.userService.Orders();
            var viewModel = new OrderViewModel(content);

            return this.View(viewModel);
        }
    }
}
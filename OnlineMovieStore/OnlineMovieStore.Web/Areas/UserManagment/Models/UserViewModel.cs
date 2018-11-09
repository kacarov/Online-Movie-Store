using OnlineMovieStore.Models.Models;
using System.Collections.Generic;

namespace OnlineMovieStore.Web.Areas.UserManagment.Models
{
    public class UserViewModel
    {
        public UserViewModel(ApplicationUser user)
        {
            this.Username = user.UserName;
            this.Balance = user.Balance;
            this.Orders = user.Orders;
        }

        public string Username { get; set; }

        public double Balance { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
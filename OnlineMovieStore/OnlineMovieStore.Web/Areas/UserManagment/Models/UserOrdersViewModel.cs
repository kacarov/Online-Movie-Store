﻿using OnlineMovieStore.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieStore.Web.Areas.UserManagment.Models
{
    public class UserOrdersViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }

        public UserOrdersViewModel(IEnumerable<Movie> movies)
        {
            this.Orders = movies.Select(m => new OrderViewModel(m));
        }
    }
}
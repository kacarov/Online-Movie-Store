using Microsoft.EntityFrameworkCore;
using OnlineMovieStore.Client.UsersSession.Contracts;
using OnlineMovieStore.Data.Repository.Contracts;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Services.Contracts;
using OnlineMovieStore.Services.Utilities.Constants;
using OnlineMovieStore.Services.Utilities.ExceptionHandling;
using OnlineMovieStore.Services.Utilities.ServiceValidation.Contracts;
using OnlineMovieStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMovieStore.Services.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext context;

        public OrdersService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Order> ListAllOrders()
        {

            return this.context.Orders
                .Include(m => m.Movie)
                .Include(u => u.User).ToList();
        }
    }
}

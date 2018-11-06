using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Data;
using System.Collections.Generic;

namespace OnlineMovieStore.Services
{
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        //TODO: GET ORDERS OF THE CURRENT USER
        public IEnumerable<Order> Orders()
        {
            return this.context.Orders;
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieStore.Services
{
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        //TODO: GET ORDERS OF THE CURRENT USER
        public IEnumerable<Movie> Orders(string id)
        {
            return this.context.Orders
               .Where(u => u.UserId == id)
               .Select(m => m.Movie)
               .Include(m => m.Genres)
                .ThenInclude(mg => mg.Genre)
               .Include(m => m.Actor)
               .ToList();
        }

        //TODO: Validations
        public ApplicationUser GetUser(string id)
        {
            return this.context.Users.Find(id);
        }

        public IEnumerable<Movie> OrdersDetails(string id)
        {
            return this.context.Orders
               .Where(u => u.UserId == id)
               .Select(m => m.Movie)
               .ToList();
        }

        public ApplicationUser AddToVallet(double amount, string userId)
        {
            var user = this.context.Users.Find(userId);
            user.Balance += amount;

            this.context.SaveChanges();

            return user;
        }

        public double GetBalance(string id)
        {
            var user = this.context.Users.Find(id);

            return user.Balance;
        }

        public ApplicationUser UpdateAccountDetails(string UserName, string Email, string PhoneNumber, string userId)
        {
            var user = this.context.Users.Find(userId);

            user.UserName = UserName;
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            user.NormalizedUserName = UserName.ToUpper();

            this.context.SaveChanges();

            userManager.UpdateAsync(user);

            return user;
        }

        public IEnumerable<ApplicationUser> GetAllUsers(int page = 1, int pageSize = 10)
        {
            return this.context.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int Total()
        {
            return this.context.Users.Count();
        }

        public int TotalContainingText(string searchText)
        {
            return this.context.Users.Where(u => u.UserName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).Count();
        }

        public IEnumerable<ApplicationUser> UsersContainingText(string searchText, int page = 1, int pageSize = 10)
        {
            return this.context.Users.Where(u => u.UserName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
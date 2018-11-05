using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMovieStore.Services.Contracts
{
    public interface IUsersService
    {
        string RegisterUser(string userName, string password, double balance);

        string Login(string userName, string password);

        string Logout();

        string DeleteUser(string userName, string password);

        string Deposit(double balance);

        double GetBalance();
    }
}

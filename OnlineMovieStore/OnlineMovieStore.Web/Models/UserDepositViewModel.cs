using OnlineMovieStore.Models.Models;

namespace OnlineMovieStore.Web.Models
{
    public class UserDepositViewModel
    {
        public UserDepositViewModel(ApplicationUser user)
        {
            this.Balance = user.Balance;
            this.UserName = user.UserName;
        }

        public double Balance { get; set; }
        public string UserName { get; set; }
    }
}
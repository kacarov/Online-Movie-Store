using OnlineMovieStore.Models.Models;

namespace OnlineMovieStore.Web.Areas.UserManagment.Models
{
    public class OrderViewModel
    {
        public OrderViewModel(Movie movie)
        {
            this.Name = movie.Title;
            this.Price = movie.Price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }
}
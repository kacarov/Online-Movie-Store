using OnlineMovieStore.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieStore.Web.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Movie> content;

        public OrderViewModel(IEnumerable<Order> content)
        {
            this.content = content.Select(x => new Movie());
        }
    }
}
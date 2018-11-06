using OnlineMovieStore.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieStore.Web.Models
{
    public class OrderViewModel
    {
        public IEnumerable<MoviesViewModel> content;

        public OrderViewModel(IEnumerable<Movie> content)
        {
            this.content = content.Select(m => new MoviesViewModel(m));
        }
    }
}
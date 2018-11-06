using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieStore.Web.Models
{
    public class HomePageViewModel
    {
        public HomePageViewModel(IEnumerable<Movie> movies)
        {
            Movies = movies.Select(m => new MoviesViewModel(m)); 
        }

        public IEnumerable<MoviesViewModel> Movies { get; set; }
    }
}

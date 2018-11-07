using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieStore.Web.Areas.Administration.Models
{
    public class MoviesIndexViewModel
    {
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int PreviousPage => this.CurrentPage == 
            1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == 
            this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

        public IEnumerable<Movie> Movies { get; set; }
    }
}

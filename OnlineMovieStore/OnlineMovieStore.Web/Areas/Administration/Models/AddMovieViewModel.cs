using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieStore.Web.Areas.Administration.Models
{
    public class AddMovieViewModel
    {
        public string GenreId { get; set; }
        public string Title { get; set; }
        public string ActorId { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }

        public AddMovieViewModel()
        {

        }

        public AddMovieViewModel(List<Actor> actors, List<Genre> genres)
        {
            this.Genres = genres.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }).ToList();
            this.Actors = actors.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.FirstName} {a.LastName}" }).ToList();
        }
    }
}

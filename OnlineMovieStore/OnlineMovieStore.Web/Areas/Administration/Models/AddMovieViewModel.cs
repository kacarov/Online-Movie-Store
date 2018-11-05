using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMovieStore.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieStore.Web.Areas.Administration.Models
{
    public class AddMovieViewModel
    {
        public IEnumerable<string> GenreId { get; set; }
        public string Title { get; set; }
        public string ActorId { get; set; }
        public double Price { get; set; }
        public short Year { get; set; }
        public string ImageURL { get; set; }

        public GenreCheckBox[] Genres { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }

        public AddMovieViewModel()
        {

        }

        public AddMovieViewModel(List<Actor> actors, List<Genre> genres)
        {
            this.Genres = genres.Select(g => new GenreCheckBox { Id = g.Id, Name = g.Name }).ToArray();
            this.Actors = actors.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.FirstName} {a.LastName}" }).ToList();
        }
    }
}

﻿using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieStore.Web.Areas.Administration.Models
{
    public class MoviesIndexViewModel
    {
        public int TotalPages { get; set; }

        public int Page { get; set; } = 1;

        public int PreviousPage => this.Page == 
            1 ? 1 : this.Page - 1;

        public int NextPage => this.Page == 
            this.TotalPages ? this.TotalPages : this.Page + 1;

        public IEnumerable<Movie> Movies { get; set; }

        public string SearchText { get; set; } = string.Empty;
    }
}

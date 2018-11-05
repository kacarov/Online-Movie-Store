using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;

namespace OnlineMovieStore.Services.Contracts
{
    public interface IMoviesService
    {
        Movie AddMovie(string image, string title, short year, List<Genre> genres, int actorId, double price);

        IEnumerable<Movie> ListAllMovies();

        IEnumerable<Movie> ListMoviesByActor(string firstName, string lastName);

        IEnumerable<Movie> ListMoviesByTitle(string name);

        IEnumerable<Movie> ListMoviesByYear(short year);

        Movie UpdateMoviePrice(string title, double price);

        Movie DeleteMovie(string title);

        string BuyMovie(string movieTitle);

        IEnumerable<Movie> ListMyMovies();
    }
}

using OnlineMovieStore.Models.Models;
using System;
using System.Collections.Generic;

namespace OnlineMovieStore.Services.Contracts
{
    public interface IMoviesService
    {
        Movie AddMovie(string image, string title, short year, List<string> genre, string actorFirstName, string actorLastName, double price);

        List<Movie> ListAllMovies();

        List<Movie> ListMoviesByActor(string firstName, string lastName);

        List<Movie> ListMoviesByTitle(string name);

        List<Movie> ListMoviesByYear(short year);

        Movie UpdateMoviePrice(string title, double price);

        Movie DeleteMovie(string title);

        string BuyMovie(string movieTitle);

        List<Movie> ListMyMovies();
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineMovieStore.Models.Models;
using OnlineMovieStore.Services.Contracts;
using OnlineMovieStore.Services.Exceptions;
using OnlineMovieStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMovieStore.Services.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext context;

        public MoviesService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Movie AddMovie(string image, string title, short year, List<string> genre, string actorFirstName, string actorLastName, double price)
        {

            if(image == null)
            {
                throw new ArgumentNullException("Image cannot be null!");
            }

            if(title == null)
            {
                throw new ArgumentNullException("Title cannot be null!");
            }

            if(title.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Title lenght cannot be more than 40 symbols!");
            }

            if(actorFirstName == null)
            {
                throw new ArgumentNullException("Actor first name cannot be null!");
            }

            if (actorFirstName.Length > 25)
            {
                throw new ArgumentOutOfRangeException("Actor first name cannot be more than 25 symbols!");
            }

            if(actorLastName == null)
            {
                throw new ArgumentNullException("Actor last name cannot be null!");
            }

            if (actorLastName.Length > 25)
            {
                throw new ArgumentOutOfRangeException("Actor last name cannot be more than 25 symbols!");
            }

            var movie = this.context.Movies
              .FirstOrDefault(m => m.Title == title);

            if (movie != null)
            {
                throw new EntityNotFoundException($"Movie with title {title} already exists!");
            }

            var actor = this.context.Actors
               .FirstOrDefault(a => a.FirstName == actorFirstName && a.LastName == actorLastName);

            if (actor == null)
            {
                throw new EntryPointNotFoundException($"Actor with name {actorFirstName} {actorLastName}");
            }

            List<Genre> genres = new List<Genre>();
            if (genre.Count > 0)
            {
                foreach (var g in genre)
                {
                    var gen = this.context.Genres
                        .FirstOrDefault(mg => mg.Name == g);

                    if (gen == null)
                    {
                        throw new EntryPointNotFoundException($"Genre with name {g} does not exist!");
                    }

                    genres.Add(gen);
                }
            }

            movie = new Movie
            {
                Title = title,
                Year = year,
                Price = price,
                ActorId = actor.Id

            };

            this.context.Movies.Add(movie);
            foreach (var g in genres)
            {
                this.context.GenreMovies.Add(new GenreMovie
                {
                    MovieId = movie.Id,
                    GenreId = g.Id
                });
            }
            this.context.SaveChanges();

            return movie;
        }

        public Movie DeleteMovie(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Title cannot be null!");
            }

            if (title.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Title lenght cannot be more than 40 symbols!");
            }

            var movie = this.context.Movies
                .FirstOrDefault(m => m.Title == title);

            if (movie == null)
            {
                throw new EntityNotFoundException($"Movie with title {title} does not exist!");
            }

            movie.IsDeleted = true;

            this.context.SaveChanges();

            return movie;
        }

        public List<Movie> ListAllMovies()
        {
            var moviesQuery = this.context.Movies
                .AsQueryable();

            moviesQuery = moviesQuery
                .Include(m => m.Actor)
                .Include(m => m.Genres)
                    .ThenInclude(mg => mg.Genre);

            var movies = moviesQuery.ToList();

            if (movies != null && movies.Count != 0)
            {
                return movies;
            }
            else
            {
                throw new EntityNotFoundException("Cannot find movies with this filter!");
            }
        }

        public List<Movie> ListMoviesByActor(string firstName, string lastName)
        {
            
            if(firstName == null)
            {
                throw new ArgumentNullException("Firt name cannot be null!");
            }

            if(firstName.Length > 25)
            {
                throw new ArgumentOutOfRangeException("Fist name cannot be longer than 25 symbols!");
            }

            if(lastName == null)
            {
                throw new ArgumentNullException("Last name cannot be null!");
            }

            if (lastName.Length > 25)
            {
                throw new ArgumentOutOfRangeException("Last name cannot be longer than 25 symbols!");
            }

            var moviesQuery = this.context.Movies
                .AsQueryable();

            moviesQuery = moviesQuery
                 .Include(m => m.Actor)
                 .Include(m => m.Genres)
                     .ThenInclude(mg => mg.Genre)
                 .Where(m => m.Actor.FirstName == firstName && m.Actor.LastName == lastName);

            var movies = moviesQuery.ToList();

            if (movies != null && movies.Count != 0)
            {
                return movies;
            }
            else
            {
                throw new EntityNotFoundException("Cannot find movies with this filter!");
            }
        }

        public List<Movie> ListMoviesByTitle(string title)
        {

            if (title == null)
            {
                throw new ArgumentNullException("Title cannot be null");
            }

            if(title.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Title length cannot be more than 40 symbols");
            }

            var moviesQuery = this.context.Movies
                .AsQueryable();

            moviesQuery = moviesQuery
               .Include(m => m.Actor)
               .Include(m => m.Genres)
                   .ThenInclude(mg => mg.Genre)
               .Where(m => m.Title == title);

            var movies = moviesQuery.ToList();

            if (movies != null && movies.Count != 0)
            {
                return movies;
            }
            else
            {
                throw new EntityNotFoundException("Cannot find movies with this filter!");
            }

        }

        public List<Movie> ListMoviesByYear(short year)
        {

            if (year < 1800 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("Year must be in between 1800 and 9999");
            }

            var moviesQuery = this.context.Movies
                .AsQueryable();

            moviesQuery = moviesQuery
               .Include(m => m.Actor)
               .Include(m => m.Genres)
                   .ThenInclude(mg => mg.Genre)
               .Where(m => m.Year == year);

            var movies = moviesQuery.ToList();

            if (movies != null && movies.Count != 0)
            {
                return movies;
            }
            else
            {
                throw new EntityNotFoundException("Cannot find movies with this filter!");
            }
        }

        public Movie UpdateMoviePrice(string title, double price)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Title cannot be null!");
            }

            if (title.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Title lenght cannot be more than 40 symbols!");
            }

            if(price < 1 || price > 200)
            {
                throw new ArgumentOutOfRangeException("Price must be between 1 and 200$!");
            }

            var movie = this.context.Movies
                .FirstOrDefault(m => m.Title == title);

            if (movie == null)
            {
                throw new EntityNotFoundException($"Movie with title {title} does not exist!");
            }

            if (price == movie.Price)
            {
                throw new ArgumentException($"{title} price is already {price:F2}$!");
            }

            movie.Price = price;

            this.context.SaveChanges();

            return movie;
        }

        //TODO: NEEDS USER INFO
        public string BuyMovie(string movieTitle)
        {
            if (movieTitle == null)
            {
                throw new ArgumentNullException("Title cannot be null!");
            }

            var movie = this.context.Movies
                .FirstOrDefault(m => m.Title == movieTitle);


            if (movie == null)
            {
                throw new EntityNotFoundException($"Movie with title {movieTitle} already exists!");
            }

          /*  var user = this.unitOfWork.GetRepo<User>().All()
                .FirstOrDefault(u => u.Username == this.userSession.user.Username);

            if (user.Balance < movie.Price)
            {
                throw new ArgumentException("You don't have enough money to buy this movie!");
            }

            this.context.WatchedMovies.Add(new WatchedMovies
            {
                UserId = user.Id,
                MovieId = movie.Id
            });

            this.context.Orders.Add(new Order
            {
                UserId = user.Id,
                MovieId = movie.Id,
                Date = DateTime.Now
            });

            user.Balance -= movie.Price;

            this.context.SaveChanges();
            */
            return "You have succesfully added movie to your collection.";
        }
        //TODO: NEEDS USER INFO2
        public List<Movie> ListMyMovies()
        {
            /*var user = this.unitOfWork.GetRepo<User>().All()
                .FirstOrDefault(u => u.Username == this.userSession.user.Username);

            var watchedMovies = this.context.WatchedMovies
                .Where(u => u.UserId == user.Id)
                .Select(m => m.Movie)
                .Include(m => m.Genres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.Actor)
                .ToList();

            if (watchedMovies != null && watchedMovies.Count != 0)
            {
                return watchedMovies;
            }
            else
            {
                throw new EntityNotFoundException("Cannot find movies with this filter!");
            }*/
            return new List<Movie>();
        }
    }
}

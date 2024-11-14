using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.DataModels;
using Watchlist.Interfaces;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task AddMovieToCollectionAsync(string userId, int movieId)
        {
            if (await context.UsersMovies.AnyAsync(um => um.UserId == userId && um.MovieId == movieId) == false)
            {
                UserMovie userMovie = new()
                {
                    UserId = userId,
                    MovieId = movieId
                };

                await context.UsersMovies.AddAsync(userMovie);

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateMovieAndAddAsync(MovieFormModel model)
        {
            Movie movie = new()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<GenreViewModel>> GetAllGenresAsync()
        {
            ICollection<GenreViewModel> allGenres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            return allGenres;
        }

        public async Task<ICollection<MovieViewModel>> GetAllMoviesAsync()
        {
            ICollection<MovieViewModel> allMovies = await context.Movies
                .AsNoTracking()
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name,
                    Rating = m.Rating
                })
                .ToListAsync();

            return allMovies;
        }

        public async Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(string userId)
        {
            ICollection<MovieViewModel> allWatchedMovies = await context.UsersMovies
                .AsNoTracking()
                .Where(um => um.UserId == userId)
                .Select(um => new MovieViewModel()
                {
                    Id = um.Movie.Id,
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    ImageUrl = um.Movie.ImageUrl,
                    Rating = um.Movie.Rating,
                    Genre = um.Movie.Genre.Name
                })
                .ToListAsync();

            return allWatchedMovies;
        }

        public async Task<bool> IsMovieExisting(int movieId)
        {
            Movie? movie = await context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == movieId);

            return movie != null;
        }

        public async Task RemoveMovieFromCollectionAsync(string userId, int movieId)
        {
            if (await context.UsersMovies.AnyAsync(um => um.UserId == userId && um.MovieId == movieId))
            {
                UserMovie userMovie = await context.UsersMovies
                    .FirstAsync(um => um.UserId == userId && um.MovieId == movieId);

                context.UsersMovies.Remove(userMovie);

                await context.SaveChangesAsync();
            }
        }
    }
}

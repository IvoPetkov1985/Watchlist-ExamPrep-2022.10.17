using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.DataModels;
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

        public async Task AddMovieToCollectionAsync(string userId, int id)
        {
            UserMovie entry = new()
            {
                UserId = userId,
                MovieId = id
            };

            if (await context.UsersMovies.ContainsAsync(entry) == false)
            {
                await context.UsersMovies.AddAsync(entry);

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateMovieAsync(MovieFormModel model)
        {
            Movie movie = new()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId,
            };

            await context.Movies.AddAsync(movie);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreViewModel>> GetAllGenresAsync()
        {
            IEnumerable<GenreViewModel> allGenres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            return allGenres;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync()
        {
            IEnumerable<MovieViewModel> allMovies = await context.Movies
                .AsNoTracking()
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                })
                .ToListAsync();

            return allMovies;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllWatchedMoviesAsync(string userId)
        {
            IEnumerable<MovieViewModel> watchedMovies = await context.UsersMovies
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

            return watchedMovies;
        }

        public async Task<bool> IsEntryExistingAsync(string userId, int id)
        {
            UserMovie? entry = await context.UsersMovies
                .AsNoTracking()
                .SingleOrDefaultAsync(um => um.UserId == userId && um.MovieId == id);

            return entry != null;
        }

        public async Task<bool> IsMovieExistingAsync(int id)
        {
            Movie? movie = await context.Movies
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            return movie != null;
        }

        public async Task RemoveMovieFromCollectionAsync(string userId, int id)
        {
            UserMovie entry = new()
            {
                UserId = userId,
                MovieId = id
            };

            context.UsersMovies.Remove(entry);

            await context.SaveChangesAsync();
        }
    }
}

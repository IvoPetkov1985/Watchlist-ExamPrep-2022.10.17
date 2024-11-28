using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task AddMovieToCollectionAsync(string userId, int id);

        Task CreateMovieAsync(MovieFormModel model);

        Task<IEnumerable<GenreViewModel>> GetAllGenresAsync();

        Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync();

        Task<IEnumerable<MovieViewModel>> GetAllWatchedMoviesAsync(string userId);

        Task<bool> IsEntryExistingAsync(string userId, int id);

        Task<bool> IsMovieExistingAsync(int id);

        Task RemoveMovieFromCollectionAsync(string userId, int id);
    }
}

using Watchlist.Models;

namespace Watchlist.Interfaces
{
    public interface IMovieService
    {
        Task<ICollection<MovieViewModel>> GetAllMoviesAsync();

        Task<ICollection<GenreViewModel>> GetAllGenresAsync();

        Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(string userId);

        Task CreateMovieAndAddAsync(MovieFormModel model);

        Task<bool> IsMovieExisting(int movieId);

        Task AddMovieToCollectionAsync(string userId, int movieId);

        Task RemoveMovieFromCollectionAsync(string userId, int movieId);
    }
}

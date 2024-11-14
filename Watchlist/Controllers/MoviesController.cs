using Microsoft.AspNetCore.Mvc;
using Watchlist.Interfaces;
using Watchlist.Models;
using static Watchlist.Data.Constants.DataConstants;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMovieService service;

        public MoviesController(IMovieService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<MovieViewModel> model = await service.GetAllMoviesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ICollection<GenreViewModel> genres = await service.GetAllGenresAsync();

            MovieFormModel model = new()
            {
                Genres = genres
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            ICollection<GenreViewModel> genres = await service.GetAllGenresAsync();

            if (genres.Any(g => g.Id == model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), GenreNotExists);
            }

            if (ModelState.IsValid == false)
            {
                model.Genres = genres;

                return View(model);
            }

            await service.CreateMovieAndAddAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            bool isMovieExisting = await service.IsMovieExisting(movieId);

            if (isMovieExisting == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.AddMovieToCollectionAsync(userId, movieId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string userId = GetUserId();

            ICollection<MovieViewModel> model = await service.GetAllWatchedMoviesAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            bool isMovieExisting = await service.IsMovieExisting(movieId);

            if (isMovieExisting == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.RemoveMovieFromCollectionAsync(userId, movieId);

            return RedirectToAction(nameof(Watched));
        }
    }
}

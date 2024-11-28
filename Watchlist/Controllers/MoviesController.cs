using Microsoft.AspNetCore.Mvc;
using Watchlist.Contracts;
using Watchlist.Models;
using static Watchlist.Data.Common.DataConstants;

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
            IEnumerable<MovieViewModel> model = await service.GetAllMoviesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<GenreViewModel> genres = await service.GetAllGenresAsync();

            MovieFormModel model = new()
            {
                Genres = genres
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            IEnumerable<GenreViewModel> genres = await service.GetAllGenresAsync();

            if (genres.Any(g => g.Id == model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), GenreErrorMsg);
            }

            if (ModelState.IsValid == false)
            {
                model.Genres = genres;

                return View(model);
            }

            await service.CreateMovieAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string userId = GetUserId();

            IEnumerable<MovieViewModel> model = await service.GetAllWatchedMoviesAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            if (await service.IsMovieExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            await service.AddMovieToCollectionAsync(userId, id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            if (await service.IsMovieExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            if (await service.IsEntryExistingAsync(userId, id) == false)
            {
                return NotFound();
            }

            await service.RemoveMovieFromCollectionAsync(userId, id);

            return RedirectToAction(nameof(Watched));
        }
    }
}

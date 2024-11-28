using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Watchlist.Data.Common.DataConstants;

namespace Watchlist.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, MoviesContrName);
            }

            return View();
        }
    }
}

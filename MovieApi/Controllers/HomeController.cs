using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Models;
using MovieApi.Services;
using MovieApi.ViewModel;
using System.Diagnostics;

namespace MovieApi.Controllers
{ // dto - это viweModel
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieApiServices _movieApiServices;

        public HomeController(ILogger<HomeController> logger, IMovieApiServices movieApiServices)
        {
            _movieApiServices = movieApiServices;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string title, int page = 1)
        {
            var result = await _movieApiServices.SearchByTitle(title, page);
            //ViewBag.TotalResults = result.TotalResults;
            //ViewBag.TotalPages = Math.Ceiling(result.TotalResults / 10D);
            //ViewBag.CurentPage = page;
            //ViewBag.MovieTitle = title;

            SearchViweModel serchViewModel = new()
            {
                CurrentPage = page,
                Title = title,
                TotalPages = (int)Math.Ceiling(result.TotalResults / 10D),
                Movies = result.Movies,
                TotalResults = result.TotalResults,
            };
            return View(serchViewModel);
        }
        public async Task<IActionResult> Movie(string id)
        {
            Movie movie = await _movieApiServices.SearchById(id);
            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{


    public class HomeController : Controller
    {
        private readonly MusicStoreContext _context = new MusicStoreContext();

        public IActionResult Index()
        {
            var guitars = _context.Guitar.ToList();

            return View(guitars);
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

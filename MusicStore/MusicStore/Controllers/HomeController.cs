using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public enum ItemType
    {
        ElectricGuitar,
        AcousticGuitar,
        ClassicalGuitar,
        Bass,
        AmpElectricGuitar,
        AmpBass,
        Drums,
        Piano,
        EffectGuitar,
        EffectBass
    }

    public class HomeController : Controller
    {
        #region Variables & Constructor

        private readonly MusicStoreContext _context = new MusicStoreContext();
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        public IActionResult Index()
        {
            var items = _context.Item.ToList();

            return View(items);
        }

        public IActionResult ShopDetails(int id)
        {
            var item = _context.Item.First(c => c.Id == id);

            return View(item);
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

        public IActionResult ViewAll()
        {
            var items = _context.Item.ToList();

            return View(items);
        }

        public IActionResult ShopGrid(int? id, string name, string minamount, string maxamount)
        {
            var items = id == null ? _context.Item : _context.Item.Where(c => c.Type == id);

            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            if (!string.IsNullOrEmpty(name))
            {
                items = items.Where(s =>
                    compareInfo.IndexOf(s.Name, name,
                        CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) > -1);
            }
            
            if (minamount != null && maxamount != null)
            {
                maxamount = maxamount.Replace("RON", "");
                items = items.Where(s => s.Price >= int.Parse(minamount) && s.Price <= int.Parse(maxamount));
            }

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create_Post(ItemViewModel input)
        {
            string uniqueFileName = null;
            if (input.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploaded-images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + input.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                input.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }



            var item = new Item
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                Availability = input.Availability,
                Photo = uniqueFileName,
                ReviewNumber = input.ReviewNumber,
                Stars = input.Stars,
                Model = input.Model,
                Serie = input.Serie,
                Forma = input.Forma,
                Material = input.Material,
                Finisaj = input.Finisaj,
                NumarTaste = input.NumarTaste,
                Doze = input.Doze,
                Type = (int)input.Type,
            };


            _context.Item.Add(item);
            _context.SaveChanges();
            return RedirectToAction("ViewAll");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Item.First(c => c.Id == id);

            _context.Item.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("ViewAll");
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}

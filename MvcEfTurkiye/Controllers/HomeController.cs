using Microsoft.AspNetCore.Mvc;
using MvcEfTurkiye.Data;
using MvcEfTurkiye.Models;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MvcEfTurkiye.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;

        public HomeController(ILogger<HomeController> logger, UygulamaDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sehir(string ara)
        {
            IQueryable<Sehir> sehirler = _db.Sehirler;
            if (!string.IsNullOrEmpty(ara))
            {
                sehirler = sehirler.Where(x => x.SehirAd.Contains(ara));
            }
            return View(sehirler.ToList());
        }

        public IActionResult SehirlerHarfIle(string harf)
        {
            IQueryable<Sehir> sehirler = _db.Sehirler;

            if (!string.IsNullOrEmpty(harf))
            {
                sehirler = sehirler.Where(x => x.SehirAd.StartsWith(harf));
            }

            return View(sehirler.ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

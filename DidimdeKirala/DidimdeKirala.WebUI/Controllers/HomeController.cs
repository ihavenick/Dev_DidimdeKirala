using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DidimdeKirala.WebUI.Data;
using Microsoft.EntityFrameworkCore;

namespace DidimdeKirala.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.KiralananEvler.Include(kiralik => kiralik.KiralıkEvinMahallesi).Include(item => item.KiralıkEvinMahallesi.MahalleninIlcesi).Include(item => item.Resimler).ToList());
        }

        public IActionResult Goruntule(int? ilanNo)
        {
            if (ilanNo != null)
            {
                KiralikEvler ke = _context.KiralananEvler.Include(kiralik => kiralik.KiralıkEvinMahallesi).Include(item => item.KiralıkEvinMahallesi.MahalleninIlcesi).Include(item => item.Resimler).Include(item => item.EmlakinTipi).Where(x => x.KiralikEvlerID == ilanNo).FirstOrDefault();
                ViewBag.deneme = ke.Resimler.ToList();
                ViewBag.Harita = "https://www.google.com/maps/embed/v1/place?q=" + ke.HaritaEnlem + "," + ke.HaritaBoylam + "&key=AIzaSyBDY748Cze_xf6hLj0hOdrNZbt8NNaBr60";
                return View(ke);
            }
            return RedirectToAction("Home");
        }

        public IActionResult Iletisim()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

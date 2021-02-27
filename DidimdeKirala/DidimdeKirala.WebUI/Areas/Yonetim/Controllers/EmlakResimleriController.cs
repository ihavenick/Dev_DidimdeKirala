using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DidimdeKirala.WebUI.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DidimdeKirala.WebUI.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class EmlakResimleriController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public EmlakResimleriController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Yonetim/EmlakResimleri
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmlaginResimleri.Include(e => e.ResminEvi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yonetim/EmlakResimleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlakResimleri = await _context.EmlaginResimleri
                .Include(e => e.ResminEvi)
                .SingleOrDefaultAsync(m => m.EmlakResimleriID == id);
            if (emlakResimleri == null)
            {
                return NotFound();
            }

            return View(emlakResimleri);
        }

        // GET: Yonetim/EmlakResimleri/Create
        public IActionResult Create(int? KiralikEvlerID)
        {
            ViewData["KiralikEvlerID"] = new SelectList(_context.KiralananEvler, "KiralikEvlerID", "KiralikEvlerID");
            if (KiralikEvlerID.HasValue)
            {
                EmlakResimleri ER = new EmlakResimleri()
                {
                    KiralikEvlerID = KiralikEvlerID.Value,
                };
                return View(ER);
            }
            return View();
        }

        // POST: Yonetim/EmlakResimleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmlakResimleriID,KiralikEvlerID,ResimdosyaAd")] EmlakResimleri emlakResimleri, ICollection<IFormFile> dosyalar)
        {
            if (ModelState.IsValid)
            {
                var yuklenenler = Path.Combine(_environment.WebRootPath, "Yuklenenler");
                foreach (var dosya in dosyalar)
                {
                    if (dosya.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(yuklenenler, dosya.FileName), FileMode.Create))
                        {
                            await dosya.CopyToAsync(fileStream);
                            EmlakResimleri de = new EmlakResimleri()
                            {
                                 KiralikEvlerID = emlakResimleri.KiralikEvlerID,
                                  ResimdosyaAd =  "yuklenenler/"+dosya.FileName
                            };
                            _context.Add(de);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["KiralikEvlerID"] = new SelectList(_context.KiralananEvler, "KiralikEvlerID", "KiralikEvlerID", emlakResimleri.KiralikEvlerID);
            return View(emlakResimleri);
        }



        // GET: Yonetim/EmlakResimleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlakResimleri = await _context.EmlaginResimleri.SingleOrDefaultAsync(m => m.EmlakResimleriID == id);
            if (emlakResimleri == null)
            {
                return NotFound();
            }
            ViewData["KiralikEvlerID"] = new SelectList(_context.KiralananEvler, "KiralikEvlerID", "KiralikEvlerID", emlakResimleri.KiralikEvlerID);
            return View(emlakResimleri);
        }

        // POST: Yonetim/EmlakResimleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmlakResimleriID,KiralikEvlerID,ResimdosyaAd")] EmlakResimleri emlakResimleri)
        {
            if (id != emlakResimleri.EmlakResimleriID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emlakResimleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmlakResimleriExists(emlakResimleri.EmlakResimleriID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["KiralikEvlerID"] = new SelectList(_context.KiralananEvler, "KiralikEvlerID", "KiralikEvlerID", emlakResimleri.KiralikEvlerID);
            return View(emlakResimleri);
        }

        // GET: Yonetim/EmlakResimleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlakResimleri = await _context.EmlaginResimleri
                .Include(e => e.ResminEvi)
                .SingleOrDefaultAsync(m => m.EmlakResimleriID == id);
            if (emlakResimleri == null)
            {
                return NotFound();
            }

            return View(emlakResimleri);
        }

        // POST: Yonetim/EmlakResimleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emlakResimleri = await _context.EmlaginResimleri.SingleOrDefaultAsync(m => m.EmlakResimleriID == id);
            _context.EmlaginResimleri.Remove(emlakResimleri);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmlakResimleriExists(int id)
        {
            return _context.EmlaginResimleri.Any(e => e.EmlakResimleriID == id);
        }
    }
}

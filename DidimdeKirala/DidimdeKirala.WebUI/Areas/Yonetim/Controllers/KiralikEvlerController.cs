using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DidimdeKirala.WebUI.Data;

namespace DidimdeKirala.WebUI.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class KiralikEvlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KiralikEvlerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Yonetim/KiralikEvler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KiralananEvler.Include(k => k.EmlakinTipi).Include(k => k.KiralıkEvinMahallesi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yonetim/KiralikEvler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiralikEvler = await _context.KiralananEvler
                .Include(k => k.EmlakinTipi)
                .Include(k => k.KiralıkEvinMahallesi)
                .SingleOrDefaultAsync(m => m.KiralikEvlerID == id);
            if (kiralikEvler == null)
            {
                return NotFound();
            }

            return View(kiralikEvler);
        }

        // GET: Yonetim/KiralikEvler/Create
        public IActionResult Create()
        {
            ViewData["EmlakTipiID"] = new SelectList(_context.EmlakTipleri, "EmlakTipiID", "EmlakTipiID");
            ViewData["MahalleID"] = new SelectList(_context.Mahalleler, "MahalleID", "MahalleID");
            return View();
        }

        // POST: Yonetim/KiralikEvler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KiralikEvlerID,IlanBaslik,IlanAcıklama,IlanTarihi,OdaSayısı,IlanFiyatı,EmlakTipiID,M2,BinaYasi,BulunduguKat,KatSayısı,Isıtma,BanyoSayısı,Esyalımı,SiteIcindemi,SeciliIlkResimID,HaritaEnlem,HaritaBoylam,MahalleID,Aktifmi")] KiralikEvler kiralikEvler)
        {
            if (ModelState.IsValid)
            {
                kiralikEvler.DegismeTarihi = DateTime.Now;
                kiralikEvler.YaratılmaTarihi = DateTime.Now;
                _context.Add(kiralikEvler);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "EmlakResimleri", new { KiralikEvlerID = kiralikEvler.KiralikEvlerID });
            }
            ViewData["EmlakTipiID"] = new SelectList(_context.EmlakTipleri, "EmlakTipiID", "EmlakTipiID", kiralikEvler.EmlakTipiID);
            ViewData["MahalleID"] = new SelectList(_context.Mahalleler, "MahalleID", "MahalleID", kiralikEvler.MahalleID);
            return View(kiralikEvler);
        }

        // GET: Yonetim/KiralikEvler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiralikEvler = await _context.KiralananEvler.SingleOrDefaultAsync(m => m.KiralikEvlerID == id);
            if (kiralikEvler == null)
            {
                return NotFound();
            }
            ViewData["EmlakTipiID"] = new SelectList(_context.EmlakTipleri, "EmlakTipiID", "EmlakTipiID", kiralikEvler.EmlakTipiID);
            ViewData["MahalleID"] = new SelectList(_context.Mahalleler, "MahalleID", "MahalleID", kiralikEvler.MahalleID);
            return View(kiralikEvler);
        }

        // POST: Yonetim/KiralikEvler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KiralikEvlerID,IlanBaslik,IlanAcıklama,IlanTarihi,IlanFiyatı,OdaSayısı,EmlakTipiID,M2,BinaYasi,BulunduguKat,KatSayısı,Isıtma,BanyoSayısı,Esyalımı,SiteIcindemi,SeciliIlkResimID,HaritaEnlem,HaritaBoylam,MahalleID,YaratılmaTarihi,Aktifmi")] KiralikEvler kiralikEvler)
        {
            if (id != kiralikEvler.KiralikEvlerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kiralikEvler.DegismeTarihi = DateTime.Now;
                    _context.Update(kiralikEvler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KiralikEvlerExists(kiralikEvler.KiralikEvlerID))
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
            ViewData["EmlakTipiID"] = new SelectList(_context.EmlakTipleri, "EmlakTipiID", "EmlakTipiID", kiralikEvler.EmlakTipiID);
            ViewData["MahalleID"] = new SelectList(_context.Mahalleler, "MahalleID", "MahalleID", kiralikEvler.MahalleID);
            return View(kiralikEvler);
        }

        // GET: Yonetim/KiralikEvler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiralikEvler = await _context.KiralananEvler
                .Include(k => k.EmlakinTipi)
                .Include(k => k.KiralıkEvinMahallesi)
                .SingleOrDefaultAsync(m => m.KiralikEvlerID == id);
            if (kiralikEvler == null)
            {
                return NotFound();
            }

            return View(kiralikEvler);
        }

        // POST: Yonetim/KiralikEvler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kiralikEvler = await _context.KiralananEvler.SingleOrDefaultAsync(m => m.KiralikEvlerID == id);
            _context.KiralananEvler.Remove(kiralikEvler);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KiralikEvlerExists(int id)
        {
            return _context.KiralananEvler.Any(e => e.KiralikEvlerID == id);
        }
    }
}

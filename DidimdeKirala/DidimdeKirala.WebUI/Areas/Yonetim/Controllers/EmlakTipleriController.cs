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
    public class EmlakTipleriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmlakTipleriController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Yonetim/EmlakTipleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmlakTipleri.ToListAsync());
        }

        // GET: Yonetim/EmlakTipleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlakTipi = await _context.EmlakTipleri
                .SingleOrDefaultAsync(m => m.EmlakTipiID == id);
            if (emlakTipi == null)
            {
                return NotFound();
            }

            return View(emlakTipi);
        }

        // GET: Yonetim/EmlakTipleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/EmlakTipleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmlakTipiID,EmlakTipiAdi")] EmlakTipi emlakTipi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emlakTipi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emlakTipi);
        }

        // GET: Yonetim/EmlakTipleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlakTipi = await _context.EmlakTipleri.SingleOrDefaultAsync(m => m.EmlakTipiID == id);
            if (emlakTipi == null)
            {
                return NotFound();
            }
            return View(emlakTipi);
        }

        // POST: Yonetim/EmlakTipleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmlakTipiID,EmlakTipiAdi")] EmlakTipi emlakTipi)
        {
            if (id != emlakTipi.EmlakTipiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emlakTipi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmlakTipiExists(emlakTipi.EmlakTipiID))
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
            return View(emlakTipi);
        }

        // GET: Yonetim/EmlakTipleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emlakTipi = await _context.EmlakTipleri
                .SingleOrDefaultAsync(m => m.EmlakTipiID == id);
            if (emlakTipi == null)
            {
                return NotFound();
            }

            return View(emlakTipi);
        }

        // POST: Yonetim/EmlakTipleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emlakTipi = await _context.EmlakTipleri.SingleOrDefaultAsync(m => m.EmlakTipiID == id);
            _context.EmlakTipleri.Remove(emlakTipi);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmlakTipiExists(int id)
        {
            return _context.EmlakTipleri.Any(e => e.EmlakTipiID == id);
        }
    }
}

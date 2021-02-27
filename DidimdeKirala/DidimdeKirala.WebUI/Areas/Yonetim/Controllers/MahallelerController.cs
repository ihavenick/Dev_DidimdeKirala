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
    public class MahallelerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MahallelerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Yonetim/Mahalleler
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mahalleler.Include(m => m.MahalleninIlcesi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yonetim/Mahalleler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahalle = await _context.Mahalleler
                .Include(m => m.MahalleninIlcesi)
                .SingleOrDefaultAsync(m => m.MahalleID == id);
            if (mahalle == null)
            {
                return NotFound();
            }

            return View(mahalle);
        }

        // GET: Yonetim/Mahalleler/Create
        public IActionResult Create()
        {
            ViewData["IlceID"] = new SelectList(_context.Ilceler, "IlceID", "IlceID");
            return View();
        }

        // POST: Yonetim/Mahalleler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MahalleID,MahalleAd,IlceID")] Mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mahalle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IlceID"] = new SelectList(_context.Ilceler, "IlceID", "IlceID", mahalle.IlceID);
            return View(mahalle);
        }

        // GET: Yonetim/Mahalleler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahalle = await _context.Mahalleler.SingleOrDefaultAsync(m => m.MahalleID == id);
            if (mahalle == null)
            {
                return NotFound();
            }
            ViewData["IlceID"] = new SelectList(_context.Ilceler, "IlceID", "IlceID", mahalle.IlceID);
            return View(mahalle);
        }

        // POST: Yonetim/Mahalleler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MahalleID,MahalleAd,IlceID")] Mahalle mahalle)
        {
            if (id != mahalle.MahalleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MahalleExists(mahalle.MahalleID))
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
            ViewData["IlceID"] = new SelectList(_context.Ilceler, "IlceID", "IlceID", mahalle.IlceID);
            return View(mahalle);
        }

        // GET: Yonetim/Mahalleler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahalle = await _context.Mahalleler
                .Include(m => m.MahalleninIlcesi)
                .SingleOrDefaultAsync(m => m.MahalleID == id);
            if (mahalle == null)
            {
                return NotFound();
            }

            return View(mahalle);
        }

        // POST: Yonetim/Mahalleler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mahalle = await _context.Mahalleler.SingleOrDefaultAsync(m => m.MahalleID == id);
            _context.Mahalleler.Remove(mahalle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MahalleExists(int id)
        {
            return _context.Mahalleler.Any(e => e.MahalleID == id);
        }
    }
}

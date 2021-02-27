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
    public class IlcelerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IlcelerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Yonetim/Ilceler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ilceler.ToListAsync());
        }

        // GET: Yonetim/Ilceler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilce = await _context.Ilceler
                .SingleOrDefaultAsync(m => m.IlceID == id);
            if (ilce == null)
            {
                return NotFound();
            }

            return View(ilce);
        }

        // GET: Yonetim/Ilceler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/Ilceler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IlceID,IlceAd")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilce);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ilce);
        }

        // GET: Yonetim/Ilceler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilce = await _context.Ilceler.SingleOrDefaultAsync(m => m.IlceID == id);
            if (ilce == null)
            {
                return NotFound();
            }
            return View(ilce);
        }

        // POST: Yonetim/Ilceler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IlceID,IlceAd")] Ilce ilce)
        {
            if (id != ilce.IlceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlceExists(ilce.IlceID))
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
            return View(ilce);
        }

        // GET: Yonetim/Ilceler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilce = await _context.Ilceler
                .SingleOrDefaultAsync(m => m.IlceID == id);
            if (ilce == null)
            {
                return NotFound();
            }

            return View(ilce);
        }

        // POST: Yonetim/Ilceler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ilce = await _context.Ilceler.SingleOrDefaultAsync(m => m.IlceID == id);
            _context.Ilceler.Remove(ilce);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IlceExists(int id)
        {
            return _context.Ilceler.Any(e => e.IlceID == id);
        }
    }
}

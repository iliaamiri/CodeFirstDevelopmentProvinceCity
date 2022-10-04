using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstDevelopmentProvinceCity.Data;
using CodeFirstDevelopmentProvinceCity.Models;

namespace CodeFirstDevelopmentProvinceCity.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvincesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Provinces
        public async Task<IActionResult> Index()
        {
              return _context.Citie != null ? 
                          View(await _context.Citie.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Citie'  is null.");
        }

        // GET: Provinces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Citie == null)
            {
                return NotFound();
            }

            var city = await _context.Citie
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Provinces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,Population,ProvinceCode")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Provinces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Citie == null)
            {
                return NotFound();
            }

            var city = await _context.Citie.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,Population,ProvinceCode")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Provinces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Citie == null)
            {
                return NotFound();
            }

            var city = await _context.Citie
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Citie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Citie'  is null.");
            }
            var city = await _context.Citie.FindAsync(id);
            if (city != null)
            {
                _context.Citie.Remove(city);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
          return (_context.Citie?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}

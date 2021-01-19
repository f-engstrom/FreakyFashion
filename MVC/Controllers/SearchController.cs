using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreakyFashion.Data;
using FreakyFashion.Models;

namespace FreakyFashion.MWC.Controllers
{
    public class SearchController : Controller
    {
        private readonly FreakyFashionContext _context;

        public SearchController(FreakyFashionContext context)
        {
            _context = context;
        }

        // GET: Search
        public async Task<IActionResult> Index([Bind(Prefix = "q")] string queryString)
        {
            

                var freakyFashionContext = _context.Clothing.Where(x => x.Name.Contains(queryString));
                return View(await freakyFashionContext.ToListAsync());
        }

        // GET: Search/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // GET: Search/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Search/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl,CategoryId,ClimateCompensated")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", clothing.CategoryId);
            return View(clothing);
        }

        // GET: Search/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", clothing.CategoryId);
            return View(clothing);
        }

        // POST: Search/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl,CategoryId,ClimateCompensated")] Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingExists(clothing.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", clothing.CategoryId);
            return View(clothing);
        }

        // GET: Search/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // POST: Search/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothing = await _context.Clothing.FindAsync(id);
            _context.Clothing.Remove(clothing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingExists(int id)
        {
            return _context.Clothing.Any(e => e.Id == id);
        }
    }
}

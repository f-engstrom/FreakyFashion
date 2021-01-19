using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreakyFashion.Data;
using FreakyFashion.Models;
using FreakyFashion.MWC.Models;

namespace FreakyFashion.Controllers
{
    public class ClothingsController : Controller
    {
        private readonly FreakyFashionContext _context;

        public ClothingsController(FreakyFashionContext context)
        {
            _context = context;
        }

        // GET: Clothings
        public async Task<IActionResult> Index()
        {
            var freakyFashionContext = _context.Clothing.Include(c => c.Category);
            return View(await freakyFashionContext.ToListAsync());
        }

        // GET: Clothings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewModel viewModel = new ViewModel();
            viewModel.Clothing = _context.Clothing.ToList();

            viewModel.ClothingItem = await _context.Clothing
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Clothings/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            return View();
        }

        // POST: Clothings/Create
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", clothing.CategoryId);
            return View(clothing);
        }

        // GET: Clothings/Edit/5
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", clothing.CategoryId);
            return View(clothing);
        }

        // POST: Clothings/Edit/5
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", clothing.CategoryId);
            return View(clothing);
        }

        // GET: Clothings/Delete/5
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

        // POST: Clothings/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledge_Of_Univarsity.Models;

namespace Knowledge_Of_Univarsity.Controllers
{
    public class SuccessStoriesController : Controller
    {
        private readonly AplicationDbContext _context;

        public SuccessStoriesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuccessStories
        public async Task<IActionResult> Index()
        {
              return _context.SuccessStories != null ? 
                          View(await _context.SuccessStories.ToListAsync()) :
                          Problem("Entity set 'AplicationDbContext.SuccessStories'  is null.");
        }

        // GET: SuccessStories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SuccessStories == null)
            {
                return NotFound();
            }

            var successStory = await _context.SuccessStories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (successStory == null)
            {
                return NotFound();
            }

            return View(successStory);
        }

        // GET: SuccessStories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuccessStories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Images")] SuccessStory successStory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(successStory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(successStory);
        }

        // GET: SuccessStories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SuccessStories == null)
            {
                return NotFound();
            }

            var successStory = await _context.SuccessStories.FindAsync(id);
            if (successStory == null)
            {
                return NotFound();
            }
            return View(successStory);
        }

        // POST: SuccessStories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Images")] SuccessStory successStory)
        {
            if (id != successStory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(successStory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuccessStoryExists(successStory.Id))
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
            return View(successStory);
        }

        // GET: SuccessStories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SuccessStories == null)
            {
                return NotFound();
            }

            var successStory = await _context.SuccessStories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (successStory == null)
            {
                return NotFound();
            }

            return View(successStory);
        }

        // POST: SuccessStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SuccessStories == null)
            {
                return Problem("Entity set 'AplicationDbContext.SuccessStories'  is null.");
            }
            var successStory = await _context.SuccessStories.FindAsync(id);
            if (successStory != null)
            {
                _context.SuccessStories.Remove(successStory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuccessStoryExists(int id)
        {
          return (_context.SuccessStories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> User()
        {
            return View();
        }
    }
}

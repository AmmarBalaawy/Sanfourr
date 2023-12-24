using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledge_Of_Univarsity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Knowledge_Of_Univarsity.Controllers
{
    public class CollegesController : Controller
    {
        private readonly AplicationDbContext _context;

        public CollegesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colleges
        public async Task<IActionResult> Index()
        {

            return _context.Colleges != null ?
                        View(await _context.Colleges.Include(C => C.majors).ToListAsync()) :
                        Problem("Entity set 'AplicationDbContext.Colleges'  is null.");
        }

        // GET: Colleges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colleges == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges.Include(C => C.majors)
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // GET: Colleges/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _Create([Bind("CollegeId,Name,img")] College college)
        {

            _context.Colleges.Add(college);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Colleges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colleges == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollegeId,Name")] College college)
        {
            //college.img = _context.Colleges.Where(x => x.CollegeId == id).SingleOrDefault().img;
            _context.Update(college);
            await _context.SaveChangesAsync();
            if (id != college.CollegeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(college);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //    if (!CollegeExists(college.CollegeId))
                    //    {
                    //        return NotFound();
                    //    }
                    //    else
                    //    {
                    throw;
                }
            }
                return RedirectToAction(nameof(Index));
            //}
            return View(college);
    }

    // GET: Colleges/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Colleges == null)
        {
            return NotFound();
        }

        var college = await _context.Colleges
            .FirstOrDefaultAsync(m => m.CollegeId == id);
        if (college == null)
        {
            return NotFound();
        }

        return View(college);
    }

    // POST: Colleges/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Colleges == null)
        {
            return Problem("Entity set 'AplicationDbContext.Colleges'  is null.");
        }
        var college = await _context.Colleges.FindAsync(id);
        if (college != null)
        {
            _context.Colleges.Remove(college);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Info(int? id)
    {
        if (id == null || _context.Colleges == null)
        {
            return NotFound();
        }

        var college = await _context.Colleges.Include(C => C.majors)
            .FirstOrDefaultAsync(m => m.CollegeId == id);
        if (college == null)
        {
            return NotFound();
        }

        return View(college);
    }

    private bool CollegeExists(int id)
    {
        return (_context.Colleges?.Any(e => e.CollegeId == id)).GetValueOrDefault();
    }

}
}

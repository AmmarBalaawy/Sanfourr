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
    public class MajorsController : Controller
    {
        private readonly AplicationDbContext _context;

        public MajorsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Majors
        public async Task<IActionResult> Index()
        {
            var aplicationDbContext = _context.Majors.Include(m => m.college);
            return View(await aplicationDbContext.ToListAsync());
        }

        // GET: Majors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Majors == null)
            {
                return NotFound();
            }

            var major = await _context.Majors
                .Include(m => m.college)
                .FirstOrDefaultAsync(m => m.MajorId == id);
            if (major == null)
            {
                return NotFound();
            }

            return View(major);
        }

        // GET: Majors/Create
        public IActionResult Create()
        {
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "CollegeId");
            return View();
        }

        // POST: Majors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MajorId,Name,Description,images,PersonSpecifications,workfields,Courses,CollegeId")] Major major)
        {

            _context.Add(major);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "CollegeId", major.CollegeId);
            return View(major);
        }

        // GET: Majors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Majors == null)
            {
                return NotFound();
            }

            var major = await _context.Majors.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "CollegeId", major.CollegeId);
            return View(major);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MajorId,Name,Description,images,PersonSpecifications,workfields,Courses,college,CollegeId")] Major major)
        {
            //if (id != major.MajorId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
                try
                {
                major.images=_context.Majors.Where(x => x.MajorId == id).SingleOrDefault().images;
                major.CollegeId = _context.Majors.Where(x => x.MajorId == id).SingleOrDefault().CollegeId;
                _context.Update(major);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!MajorExists(major.MajorId))
                    //{
                    //    return NotFound();
                    //}
                    //  else
                    // {
                    throw;
                    // }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "CollegeId", major.CollegeId);
            return View(major);
        }

        // GET: Majors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Majors == null)
            {
                return NotFound();
            }

            var major = await _context.Majors
                .Include(m => m.college)
                .FirstOrDefaultAsync(m => m.MajorId == id);
            if (major == null)
            {
                return NotFound();
            }

            return View(major);
        }

        // POST: Majors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Majors == null)
            {
                return Problem("Entity set 'AplicationDbContext.Majors'  is null.");
            }
            var major = await _context.Majors.FindAsync(id);
            if (major != null)
            {
                _context.Majors.Remove(major);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MajorExists(int id)
        {
            return (_context.Majors?.Any(e => e.MajorId == id)).GetValueOrDefault();
        }
    }
}

using Knowledge_Of_Univarsity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Knowledge_Of_Univarsity.Controllers
{
    public class HomeController : Controller
    {

        private readonly AplicationDbContext _context;

        public HomeController(AplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind(include: "AdminName,Password")] Admin Admin)
        {
            if (ModelState.IsValid)
            {
                var rec = _context.Admins.Where(x => x.AdminName == Admin.AdminName && x.Password == Admin.Password).ToList();
                if (rec.Count > 0)
                {

                    return RedirectToAction("Index", "Home");
                }

            }
            return View(Admin);
        }
        public async Task<IActionResult> Index()
        {

            return _context.Universities != null ?
                        View(await _context.Universities.ToListAsync()) :
                        Problem("Entity set 'AplicationDbContext.Universities'  is null.");
        }
        public async Task<IActionResult> college()
        {

            return _context.Colleges != null ?
                        View(await _context.Colleges.Include(C => C.majors).ToListAsync()) :
                        Problem("Entity set 'AplicationDbContext.Colleges'  is null.");
        }
        public async Task<IActionResult> major(int? id)
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
        public async Task<IActionResult> MajorDetails(int? id)
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
        public async Task<IActionResult> SuccessStory()
        {
            return _context.SuccessStories != null ?
                        View(await _context.SuccessStories.ToListAsync()) :
                        Problem("Entity set 'AplicationDbContext.SuccessStories'  is null.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
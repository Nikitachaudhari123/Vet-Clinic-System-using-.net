using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic.Controllers
{
    public class PetProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PetProfiles
        public async Task<IActionResult> Index()
        {
            var profiles = await _context.PetProfiles
                .Include(p => p.Pet)
                .ToListAsync();

            return View(profiles);
        }

        // GET: PetProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var petProfile = await _context.PetProfiles
                .Include(p => p.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (petProfile == null)
                return NotFound();

            return View(petProfile);
        }

        // GET: PetProfiles/Create
        public IActionResult Create()
        {
            ViewBag.PetId = new SelectList(_context.Pets, "Id", "Name");
            return View();
        }

        // POST: PetProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetProfile petProfile, IFormFile? NotesFile)
        {
            string? finalNotes = null;

            // 1. If uploading a file → use that
            if (NotesFile != null && NotesFile.Length > 0)
            {
                using var reader = new StreamReader(NotesFile.OpenReadStream());
                finalNotes = await reader.ReadToEndAsync();
            }
            else if (!string.IsNullOrWhiteSpace(petProfile.VetNotes))
            {
                finalNotes = petProfile.VetNotes;
            }

            // 2. Neither provided → error
            if (string.IsNullOrWhiteSpace(finalNotes))
            {
                ModelState.AddModelError("VetNotes", "Type notes OR upload a .txt file.");
                ViewBag.PetId = new SelectList(_context.Pets, "Id", "Name");
                return View(petProfile);
            }

            // 3. Save notes
            petProfile.VetNotes = finalNotes;

            _context.PetProfiles.Add(petProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: PetProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var petProfile = await _context.PetProfiles.FindAsync(id);
            if (petProfile == null)
                return NotFound();

            ViewBag.PetId = new SelectList(_context.Pets, "Id", "Name", petProfile.PetId);
            return View(petProfile);
        }

        // POST: PetProfiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetProfile petProfile, IFormFile? NotesFile)
        {
            if (id != petProfile.Id)
                return NotFound();

            // Replace notes ONLY if file uploaded
            if (NotesFile != null && NotesFile.Length > 0)
            {
                using var reader = new StreamReader(NotesFile.OpenReadStream());
                petProfile.VetNotes = await reader.ReadToEndAsync();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.PetId = new SelectList(_context.Pets, "Id", "Name", petProfile.PetId);
                return View(petProfile);
            }

            _context.Update(petProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: PetProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var petProfile = await _context.PetProfiles
                .Include(p => p.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (petProfile == null)
                return NotFound();

            return View(petProfile);
        }

        // POST: PetProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petProfile = await _context.PetProfiles.FindAsync(id);

            if (petProfile != null)
                _context.PetProfiles.Remove(petProfile);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

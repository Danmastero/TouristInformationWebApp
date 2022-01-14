using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Models;
using TouristInformationWebApp.Data;

namespace TouristInformationWebApp.Controllers
{
    public class AttractionRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttractionRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttractionRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AttractionRating.Include(a => a.Attraction);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AttractionRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attractionRating = await _context.AttractionRating
                .Include(a => a.Attraction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attractionRating == null)
            {
                return NotFound();
            }

            return View(attractionRating);
        }

        // GET: AttractionRatings/Create
        public IActionResult Create()
        {
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Name");
            return View();
        }

        // POST: AttractionRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Comment,Rating,AttractionId")] AttractionRating attractionRating)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId != null)
                attractionRating.UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(attractionRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Name", attractionRating.AttractionId);
            return View(attractionRating);
        }

        // GET: AttractionRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attractionRating = await _context.AttractionRating.FindAsync(id);
            if (attractionRating == null)
            {
                return NotFound();
            }
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Description", attractionRating.AttractionId);
            return View(attractionRating);
        }

        // POST: AttractionRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Comment,Rating,AttractionId")] AttractionRating attractionRating)
        {
            if (id != attractionRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attractionRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttractionRatingExists(attractionRating.Id))
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
            ViewData["AttractionId"] = new SelectList(_context.Attraction, "Id", "Description", attractionRating.AttractionId);
            return View(attractionRating);
        }

        // GET: AttractionRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attractionRating = await _context.AttractionRating
                .Include(a => a.Attraction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attractionRating == null)
            {
                return NotFound();
            }

            return View(attractionRating);
        }

        // POST: AttractionRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attractionRating = await _context.AttractionRating.FindAsync(id);
            _context.AttractionRating.Remove(attractionRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttractionRatingExists(int id)
        {
            return _context.AttractionRating.Any(e => e.Id == id);
        }
    }
}

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
    public class HotelRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HotelRating.Include(h => h.Hotel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HotelRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRating = await _context.HotelRating
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelRating == null)
            {
                return NotFound();
            }

            return View(hotelRating);
        }

        // GET: HotelRatings/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Name");
            return View();
        }

        // POST: HotelRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Comment,Rating,HotelId")] HotelRating hotelRating)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId != null)
                hotelRating.UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(hotelRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Name", hotelRating.HotelId);
            return View(hotelRating);
        }

        // GET: HotelRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRating = await _context.HotelRating.FindAsync(id);
            if (hotelRating == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Description", hotelRating.HotelId);
            return View(hotelRating);
        }

        // POST: HotelRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Comment,Rating,HotelId")] HotelRating hotelRating)
        {
            if (id != hotelRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRatingExists(hotelRating.Id))
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
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Description", hotelRating.HotelId);
            return View(hotelRating);
        }

        // GET: HotelRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRating = await _context.HotelRating
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelRating == null)
            {
                return NotFound();
            }

            return View(hotelRating);
        }

        // POST: HotelRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRating = await _context.HotelRating.FindAsync(id);
            _context.HotelRating.Remove(hotelRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRatingExists(int id)
        {
            return _context.HotelRating.Any(e => e.Id == id);
        }
    }
}

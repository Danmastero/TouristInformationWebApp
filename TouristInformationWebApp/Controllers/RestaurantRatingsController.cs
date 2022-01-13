using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Models;
using TouristInformationWebApp.Data;

namespace TouristInformationWebApp.Controllers
{
    public class RestaurantRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestaurantRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RestaurantRating.Include(r => r.Restaurant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RestaurantRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantRating = await _context.RestaurantRating
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantRating == null)
            {
                return NotFound();
            }

            return View(restaurantRating);
        }

        // GET: RestaurantRatings/Create
        public IActionResult Create()
        {
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name");
            return View();
        }

        // POST: RestaurantRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Comment,Rating,RestaurantId")] RestaurantRating restaurantRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name", restaurantRating.RestaurantId);
            return View(restaurantRating);
        }

        // GET: RestaurantRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantRating = await _context.RestaurantRating.FindAsync(id);
            if (restaurantRating == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Cuisine", restaurantRating.RestaurantId);
            return View(restaurantRating);
        }

        // POST: RestaurantRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Comment,Rating,RestaurantId")] RestaurantRating restaurantRating)
        {
            if (id != restaurantRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantRatingExists(restaurantRating.Id))
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
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Cuisine", restaurantRating.RestaurantId);
            return View(restaurantRating);
        }

        // GET: RestaurantRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantRating = await _context.RestaurantRating
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantRating == null)
            {
                return NotFound();
            }

            return View(restaurantRating);
        }

        // POST: RestaurantRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantRating = await _context.RestaurantRating.FindAsync(id);
            _context.RestaurantRating.Remove(restaurantRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantRatingExists(int id)
        {
            return _context.RestaurantRating.Any(e => e.Id == id);
        }
    }
}

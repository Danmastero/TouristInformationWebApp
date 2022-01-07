using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristInformationWebApp.Data;
using TouristInformationWebApp.Models;

namespace TouristInformationWebApp.Controllers
{
    public class HotelCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HotelComments.Include(h => h.Hotel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HotelComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelComments = await _context.HotelComments
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (hotelComments == null)
            {
                return NotFound();
            }

            return View(hotelComments);
        }

        // GET: HotelComments/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Description");
            return View();
        }

        // POST: HotelComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Comments,ThisDateTime,HotelId,Rating")] HotelComments hotelComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Description", hotelComments.HotelId);
            return View(hotelComments);
        }

        // GET: HotelComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelComments = await _context.HotelComments.FindAsync(id);
            if (hotelComments == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Description", hotelComments.HotelId);
            return View(hotelComments);
        }

        // POST: HotelComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Comments,ThisDateTime,HotelId,Rating")] HotelComments hotelComments)
        {
            if (id != hotelComments.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelCommentsExists(hotelComments.CommentId))
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
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Description", hotelComments.HotelId);
            return View(hotelComments);
        }

        // GET: HotelComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelComments = await _context.HotelComments
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (hotelComments == null)
            {
                return NotFound();
            }

            return View(hotelComments);
        }

        // POST: HotelComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelComments = await _context.HotelComments.FindAsync(id);
            _context.HotelComments.Remove(hotelComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelCommentsExists(int id)
        {
            return _context.HotelComments.Any(e => e.CommentId == id);
        }
    }
}

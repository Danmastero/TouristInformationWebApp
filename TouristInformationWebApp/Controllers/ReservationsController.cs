﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristInformationWebApp.Data;
using TouristInformationWebApp.Models;

namespace TouristInformationWebApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<DateTime, int> availableSpotsForDay;
        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservation.Include(r => r.Tour);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Tour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            

            var tours = _context.Tour.Where(e => e.Id != null);
            foreach(var x in tours)
            {
                x.Name = x.Name + "(" + x.AvailableSpots + ")";
            }

            ViewData["TourId"] = new SelectList(_context.Tour, "Id", "Name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,NumOfSeats,TourId,Date")] Reservation reservation)
        {

            var reservationsAtCurrentDate = _context.Reservation.Where(e => e.Date.Date.Equals(reservation.Date.Date)).ToList();
            var totalSum = reservationsAtCurrentDate.Sum(e => e.NumOfSeats) + reservation.NumOfSeats; //Sum all reservations at current day

            //Take correct tour
            var tour = _context.Tour.FirstOrDefault(e => e.Id == reservation.TourId);

            var totalPrice = reservation.NumOfSeats * tour.Price;

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(userId != null) 
                reservation.UserId = userId;

            //Dodaje do viewbaga wolne miejsca na dany dzien
            var spotsForDay = tour.AvailableSpots - reservationsAtCurrentDate.Sum(e => e.NumOfSeats);
            if (spotsForDay < 0) spotsForDay = 0;


            if (ModelState.IsValid && totalSum <= tour.AvailableSpots)
            {

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Pomyślnie zarezerwowałeś {reservation.NumOfSeats} miejsc na kwotę {totalPrice.ToString("0.00")}";
                return RedirectToAction(nameof(Index));
            }
            ViewData["TourId"] = new SelectList(_context.Tour, "Id", "Description", reservation.TourId);

            TempData["Message"] = $"Nie udało zarezerwować się miejsc, możesz zarezerwować aktualnie maksymalnie {spotsForDay}";
            return RedirectToAction(nameof(Create));

        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["TourId"] = new SelectList(_context.Tour, "Id", "Description", reservation.TourId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,NumOfSeats,TourId,Date")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["TourId"] = new SelectList(_context.Tour, "Id", "Description", reservation.TourId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Tour)
                .FirstOrDefaultAsync(m => m.Id == id);

            var tour = _context.Tour.FirstOrDefault(e => e.Id == reservation.TourId);
            tour.AvailableSpots += reservation.NumOfSeats;
            _context.Update(tour);
            await _context.SaveChangesAsync();


            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}

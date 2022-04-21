using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourismWebsite.Data;
using TourismWebsite.Models;

namespace TourismWebsite.Controllers
{
    public class BookingsController : Controller
    {
        private readonly DataContext _context;

        public BookingsController(DataContext context)
        {
            _context = context;
        }

        // GET: Bookings
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Booking.Include(b => b.Agency).Include(b => b.Destination).Include(b => b.Guide).Include(b => b.Tourist);
            return View(await dataContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Agency)
                .Include(b => b.Destination)
                .Include(b => b.Guide)
                .Include(b => b.Tourist)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create

        public IActionResult Create()
        {
            ViewData["AgencyID"] = new SelectList(_context.Agency, "AgencyID", "AgencyName");
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationName");
            ViewData["GuideID"] = new SelectList(_context.Guide, "GuideID", "GuideName");
            ViewData["TouristID"] = new SelectList(_context.Tourist, "TouristID", "TouristName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,TouristID,GuideID,DestinationID,AgencyID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyID"] = new SelectList(_context.Agency, "AgencyID", "AgencyName", booking.AgencyID);
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationName", booking.DestinationID);
            ViewData["GuideID"] = new SelectList(_context.Guide, "GuideID", "GuideName", booking.GuideID);
            ViewData["TouristID"] = new SelectList(_context.Tourist, "TouristID", "TouristName", booking.TouristID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        [Authorize(Roles = "User, Administrator")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["AgencyID"] = new SelectList(_context.Agency, "AgencyID", "AgencyName", booking.AgencyID);
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationName", booking.DestinationID);
            ViewData["GuideID"] = new SelectList(_context.Guide, "GuideID", "GuideName", booking.GuideID);
            ViewData["TouristID"] = new SelectList(_context.Tourist, "TouristID", "TouristName", booking.TouristID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Administrator")]

        public async Task<IActionResult> Edit(int id, [Bind("BookingID,TouristID,GuideID,DestinationID,AgencyID")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["AgencyID"] = new SelectList(_context.Agency, "AgencyID", "AgencyName", booking.AgencyID);
            ViewData["DestinationID"] = new SelectList(_context.Destination, "DestinationID", "DestinationName", booking.DestinationID);
            ViewData["GuideID"] = new SelectList(_context.Guide, "GuideID", "GuideName", booking.GuideID);
            ViewData["TouristID"] = new SelectList(_context.Tourist, "TouristID", "TouristName", booking.TouristID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        [Authorize(Roles = "User, Administrator")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Agency)
                .Include(b => b.Destination)
                .Include(b => b.Guide)
                .Include(b => b.Tourist)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingID == id);
        }
    }
}

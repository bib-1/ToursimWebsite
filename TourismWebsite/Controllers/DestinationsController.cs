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
    public class DestinationsController : Controller
    {
        private readonly DataContext _context;

        public DestinationsController(DataContext context)
        {
            _context = context;
        }

        // GET: Destinations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destination.ToListAsync());
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .FirstOrDefaultAsync(m => m.DestinationID == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destinations/Create
        [Authorize(Roles = "User, Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> Create([Bind("DestinationID,DestinationName,DestinationLocation,DestinationDescription,DestinationPackage")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: Destinations/Edit/5
        [Authorize(Roles = "User, Administrator")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationID,DestinationName,DestinationLocation,DestinationDescription,DestinationPackage")] Destination destination)
        {
            if (id != destination.DestinationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationExists(destination.DestinationID))
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
            return View(destination);
        }

        // GET: Destinations/Delete/5
        [Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .FirstOrDefaultAsync(m => m.DestinationID == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
            return _context.Destination.Any(e => e.DestinationID == id);
        }
    }
}

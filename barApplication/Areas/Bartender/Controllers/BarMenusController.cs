using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarApplication.DataAccess.Data;
using BarApplication.Models;

namespace BarApplication.Areas.Bartender.Controllers
{
    [Area("Bartender")]
    public class BarMenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarMenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bartender/BarMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BarMenu.ToListAsync());
        }

        // GET: Bartender/BarMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barMenu = await _context.BarMenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barMenu == null)
            {
                return NotFound();
            }

            return View(barMenu);
        }

        // GET: Bartender/BarMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bartender/BarMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DrinkName,Price,Quantity")] BarMenu barMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barMenu);
        }

        // GET: Bartender/BarMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barMenu = await _context.BarMenu.FindAsync(id);
            if (barMenu == null)
            {
                return NotFound();
            }
            return View(barMenu);
        }

        // POST: Bartender/BarMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DrinkName,Price,Quantity")] BarMenu barMenu)
        {
            if (id != barMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarMenuExists(barMenu.Id))
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
            return View(barMenu);
        }

        // GET: Bartender/BarMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barMenu = await _context.BarMenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barMenu == null)
            {
                return NotFound();
            }

            return View(barMenu);
        }

        // POST: Bartender/BarMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barMenu = await _context.BarMenu.FindAsync(id);
            _context.BarMenu.Remove(barMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarMenuExists(int id)
        {
            return _context.BarMenu.Any(e => e.Id == id);
        }
    }
}

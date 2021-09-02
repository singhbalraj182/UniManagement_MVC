using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniManagement_MVC.Data;
using UniManagement_MVC.Models;

namespace UniManagement_MVC.Controllers
{
    public class ServicesController : Controller
    {
        private readonly UniDbContext _context;

        public ServicesController(UniDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var uniDbContext = _context.Service.Include(s => s.Department).Include(s => s.Lecturer).Include(s => s.Module);
            return View(await uniDbContext.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Department)
                .Include(s => s.Lecturer)
                .Include(s => s.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            ViewData["LecturerId"] = new SelectList(_context.Lecture, "Id", "Name");
            ViewData["ModuleId"] = new SelectList(_context.Module, "Id", "Name");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentId,LecturerId,ModuleId")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", service.DepartmentId);
            ViewData["LecturerId"] = new SelectList(_context.Lecture, "Id", "Name", service.LecturerId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "Id", "Name", service.ModuleId);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", service.DepartmentId);
            ViewData["LecturerId"] = new SelectList(_context.Lecture, "Id", "Name", service.LecturerId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "Id", "Name", service.ModuleId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentId,LecturerId,ModuleId")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", service.DepartmentId);
            ViewData["LecturerId"] = new SelectList(_context.Lecture, "Id", "Name", service.LecturerId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "Id", "Name", service.ModuleId);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Department)
                .Include(s => s.Lecturer)
                .Include(s => s.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Service.FindAsync(id);
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}

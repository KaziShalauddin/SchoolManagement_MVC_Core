using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentDbContext _context;

        public DepartmentController(StudentDbContext context)
        {
            _context = context;
        }
        // GET: Department
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }
       

        // GET: Department/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Department());

            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Code")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.Id == 0)
                    _context.Add(department);
                else
                {
                    _context.Update(department);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        
       
        // POST: Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        // GET: Student List
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.Include(c=>c.Department).ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        private void LoadDepartments()
        {
            try
            {
                List<Department> departments = new List<Department>();
                departments = _context.Departments.ToList();
                departments.Insert(0, new Department { Id = 0, Name = "Please select" });
                ViewBag.DepartmentList = departments;
            }
            catch (Exception ex)
            {

            }
        }

        // GET: Student/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            LoadDepartments();

            if (id == 0)
                return View(new Student());

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/AddOrEdit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FullName,RegistrationNo,DepartmentId,Roll")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Id == 0)
                    _context.Add(student);
                else
                {
                    _context.Update(student);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Students.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
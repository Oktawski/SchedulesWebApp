using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Controllers
{
    public class ExamsController : Controller
    {
        private readonly ScheduleContext _context;

        public ExamsController(ScheduleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns view with all exams.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            return View(await _context.Exams.ToListAsync());
        }

        /// <summary>
        /// Returns form to add exam.
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds exam to database.
        /// </summary>
        /// <param name="exam"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
            [Bind("Name", "Date", "ProfessorName", "CourseECTS", "Description", "SecondTerm")]
            Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Exams.Add(exam);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Deletes exam from database. Return exams list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            Exam exam = await FindById(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Finds exam by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Exam> FindById(int? id)
        {
            if (id != null)
            {
                Exam exam = await _context.Exams.FirstOrDefaultAsync(e => e.ExamID.Equals(id));
                return exam;
            }

            return null;
        }

    }
}

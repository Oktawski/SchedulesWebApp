using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ScheduleContext _context;

        public AssignmentsController(ScheduleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns view with every assignment.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            return View(await _context.Assignments.ToListAsync());
        }

        /// <summary>
        /// Returns view with form to add assignment.
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds assignment to database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
            [Bind("Name", "Description", "Date")] 
            string name, string description, DateTime date)
        {
            if (ModelState.IsValid)
            {
                Assignment assignment = new Assignment(name, description, date);

                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Deletes chosen assignment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.AssignmentID.Equals(id)); 
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Remove(assignment);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.AssignmentID.Equals(id));
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        //Todo Edit
    }

        /*[HttpPost, ActionName("{Delete}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }*/

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;
using TasksWebApp.Services;

namespace TasksWebApp.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly IScheduleService<Assignment> _service;

        public AssignmentsController(IScheduleService<Assignment> service, ScheduleContext context)
        {
            _service = service;
        }

        /// <summary>
        /// Returns view with all assignments.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAll()
        {
            return View(await _service.GetAll());
        }

        /// <summary>
        /// Returns form to add new assignment.
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds new assignment to database.
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Name", "Description", "Date")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(assignment);
                return RedirectToAction(nameof(GetAll));
            }

            return View(assignment);
        }

        /// <summary>
        /// Returns view to edit assignment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            if(id == null) return NotFound();

            Assignment assignment = _service.FindById(id).Result;

            if (assignment == null) return NotFound();

            return View(assignment);
        }

        /// <summary>
        /// Edits assignment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assignment"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
                    [Bind("Name", "Description", "Date")] Assignment assignment)
        {
            await _service.EditById(id, assignment);
            return RedirectToAction(nameof(GetAll));

        }

        /// <summary>
        /// Deletes assignment from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteById(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
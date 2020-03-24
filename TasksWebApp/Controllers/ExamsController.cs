using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;
using TasksWebApp.Services;

namespace TasksWebApp.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IScheduleService<Exam> _service;

        public ExamsController(IScheduleService<Exam> service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns view with all exams.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAll()
        {
            return View(await _service.GetAll());
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
                await _service.Add(exam);
                return RedirectToAction(nameof(GetAll));
            }

            return View(exam);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Exam exam = _service.FindById(id).Result;

            if (exam == null) return NotFound();

            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Name", "Description", "Date", "CourseECTS", "ProfessorName", "SecondTerm")]
            Exam exam)
        {
            await _service.EditById(id, exam);
            return RedirectToAction(nameof(GetAll));
        }

        /// <summary>
        /// Deletes exam from database. Return exams list.
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

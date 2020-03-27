using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksWebApp.Interfaces;
using TasksWebApp.Models;
using TasksWebApp.Services;

namespace TasksWebApp.Controllers
{
    public class OnlineMeetingsController : Controller, IScheduleController<OnlineMeeting>
    {
        private readonly IScheduleService<OnlineMeeting> _service;

        public OnlineMeetingsController(IScheduleService<OnlineMeeting> service)
        {
            _service = service;
        }


        public async Task<IActionResult> GetAll()
        {
            return View(await _service.GetAll());
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name", "Description", "Date", "CourseName",
                "ProfessorName", "Platform", "MeetingId", "Password", "Time")]
            OnlineMeeting onlineMeeting)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(onlineMeeting);
            }

            return RedirectToAction(nameof(GetAll));
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(GetAll));
            return View(_service.FindById(id).Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Name", "Description", "Date", "CourseName", "ProfessorName",
                "Platform", "MeetingId", "Password", "Time")]
            OnlineMeeting onlineMeeting)
        {
            if (ModelState.IsValid)
            {
                await _service.EditById(id, onlineMeeting);
            }

            return RedirectToAction(nameof(GetAll));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteById(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
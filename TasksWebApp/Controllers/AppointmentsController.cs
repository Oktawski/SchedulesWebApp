using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksWebApp.Interfaces;
using TasksWebApp.Models;
using TasksWebApp.Services;

namespace TasksWebApp.Controllers
{
    public class AppointmentsController : Controller, IScheduleController<Appointment>
    {
        private readonly IScheduleService<Appointment> _service;

        public AppointmentsController(IScheduleService<Appointment> service)
        {
            _service = service;
        }


        public async Task<IActionResult> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Add()
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Add(Appointment t)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Edit(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Edit(int id, Appointment t)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Services
{
    public class AppointmentsService : IScheduleService<Appointment>
    {
        private readonly ScheduleContext _repository;

        public AppointmentsService(ScheduleContext repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _repository.Appointments.ToListAsync();
        }

        public async Task Add(Appointment t)
        {
            _repository.Appointments.Add(t);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            if (id != null)
            {
                Appointment appointment = await FindById(id);
                if (appointment != null)
                {
                    _repository.Appointments.Remove(appointment);
                    await _repository.SaveChangesAsync();
                }
            }
        }
        public Task EditById(int id, Appointment t)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> FindById(int? id)
        {
            if(id != null)
            {
                Appointment appointment = await _repository.Appointments
                    .FirstOrDefaultAsync(e => e.AppointmentID.Equals(id));

                if (appointment != null)
                {
                    return appointment;
                }
            }
            return null;
        }
    }
}

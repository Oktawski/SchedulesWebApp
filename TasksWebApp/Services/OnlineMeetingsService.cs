using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Services
{
    public class OnlineMeetingsService : IScheduleService<OnlineMeeting>
    {
        private readonly ScheduleContext _repository;

        public OnlineMeetingsService(ScheduleContext repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OnlineMeeting>> GetAll()
        {
            return await _repository.OnlineMeetings.ToListAsync();
        }

        public async Task Add(OnlineMeeting zoomMeeting)
        {
            _repository.OnlineMeetings.Add(zoomMeeting);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            if(id != null)
            {
                OnlineMeeting zoomMeeting = await _repository.OnlineMeetings
                    .FirstOrDefaultAsync(e => e.OnlineMeetingId.Equals(id));
                if (zoomMeeting != null)
                {
                    _repository.OnlineMeetings.Remove(zoomMeeting);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        public async Task EditById(int id, OnlineMeeting meeting)
        {
            OnlineMeeting zoomMeeting = await FindById(id);
            if(zoomMeeting != null)
            {
                zoomMeeting.Name = meeting.Name;
                zoomMeeting.Description = meeting.Description;
                zoomMeeting.Date = meeting.Date;
                zoomMeeting.CourseName = meeting.CourseName;
                zoomMeeting.ProfessorName = meeting.ProfessorName;
                zoomMeeting.MeetingId = meeting.MeetingId;
                zoomMeeting.Password = meeting.Password;
                zoomMeeting.Time = meeting.Time;
            }

        }

        public async Task<OnlineMeeting> FindById(int? id)
        {
            if (id == null) return null;

            return await _repository.OnlineMeetings
                .FirstOrDefaultAsync(e => e.OnlineMeetingId.Equals(id));
        }
    }
}
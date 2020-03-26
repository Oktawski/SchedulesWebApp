using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Services
{
    public class ZoomMeetingService : IScheduleService<ZoomMeeting>
    {
        private readonly ScheduleContext _repository;

        public ZoomMeetingService(ScheduleContext repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ZoomMeeting>> GetAll()
        {
            return await _repository.ZoomMeetings.ToListAsync();
        }

        public async Task Add(ZoomMeeting zoomMeeting)
        {
            _repository.ZoomMeetings.Add(zoomMeeting);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            if(id != null)
            {
                ZoomMeeting zoomMeeting = await _repository.ZoomMeetings
                    .FirstOrDefaultAsync(e => e.ZoomMeetingId.Equals(id));
                if (zoomMeeting != null)
                {
                    _repository.ZoomMeetings.Remove(zoomMeeting);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        public async Task EditById(int id, ZoomMeeting meeting)
        {
            ZoomMeeting zoomMeeting = await FindById(id);
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

        public async Task<ZoomMeeting> FindById(int? id)
        {
            if (id == null) return null;

            return await _repository.ZoomMeetings
                .FirstOrDefaultAsync(e => e.ZoomMeetingId.Equals(id));
        }
    }
}
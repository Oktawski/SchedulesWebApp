using System;
using System.ComponentModel.DataAnnotations;

namespace TasksWebApp.Models
{
    public class ZoomMeeting : ScheduleAbstract
    {
        [Key] 
        public int ZoomMeetingId { get; set; }
        public string CourseName { get; set; }
        public string ProfessorName { get; set; }
        public int MeetingId { get; set; }
        public string Password { get; set; }
        public DateTime Time { get; set; }

    }
}
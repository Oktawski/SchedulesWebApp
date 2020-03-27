using System;
using System.ComponentModel.DataAnnotations;

namespace TasksWebApp.Models
{
    public class OnlineMeeting : ScheduleAbstract
    {
        //Key in database.
        [Key] 
        public int OnlineMeetingId { get; set; }
        public string CourseName { get; set; }
        public string ProfessorName { get; set; }
        public string Platform { get; set; }

        //Id of meeting.
        public int MeetingId { get; set; }
        public string Password { get; set; }
        public DateTime Time { get; set; }


        public OnlineMeeting(string name, string description, DateTime date, string courseName,
            string professorName, string platform, int meetingId, string password, DateTime time) 
            : base(name, description, date)
        {
            CourseName = courseName;
            ProfessorName = professorName;
            Platform = platform;
            MeetingId = meetingId;
            Password = password;
            Time = time;
        }

        public OnlineMeeting(string courseName, string professorName, string platform,
            int meetingId, string password, DateTime time)
        {
            CourseName = courseName;
            ProfessorName = professorName;
            Platform = platform;
            MeetingId = meetingId;
            Password = password;
            Time = time;
        }
    }
}
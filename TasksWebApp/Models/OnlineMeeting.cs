using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TasksWebApp.Models
{
    public class OnlineMeeting : ScheduleAbstract
    {
        //Key in database.
        [Key] 
        public int OnlineMeetingId { get; set; }
        
        [AllowNull]
        public string CourseName { get; set; }
        
        [AllowNull]
        public string ProfessorName { get; set; }
        
        [AllowNull]
        public string Platform { get; set; }

        //Id of meeting.
        [AllowNull]
        public int? MeetingId { get; set; }
        
        [AllowNull]
        public string Password { get; set; }
        
        [AllowNull]
        public DateTime Time { get; set; }
        

        public OnlineMeeting(string name="", string description="", DateTime date=new DateTime(), string courseName="",
            string professorName="", string platform="", int? meetingId=null, string password="", DateTime time=new DateTime()) 
            : base(name, description, date)
        {
            CourseName = courseName;
            ProfessorName = professorName;
            Platform = platform;
            MeetingId = meetingId;
            Password = password;
            Time = time;
        }

        /*public OnlineMeeting(string courseName, string professorName, string platform,
            int meetingId, string password, DateTime time)
        {
            CourseName = courseName;
            ProfessorName = professorName;
            Platform = platform;
            MeetingId = meetingId;
            Password = password;
            Time = time;
        }*/

        public OnlineMeeting() { }
    }
}
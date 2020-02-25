using System;
using System.ComponentModel.DataAnnotations;

namespace TasksWebApp.Models
{
    public class Appointment : ScheduleAbstract
    {
        [Key] public int AppointmentID { get; set; }
        [Required] public int Hour { get; set; }
        [Required] public int Minute { get; set; }

        public Appointment(string name, string description, DateTime date) 
            : base(name, description, date)
        {
        }
    }
}

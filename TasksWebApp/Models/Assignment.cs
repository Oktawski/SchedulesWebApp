using System;
using System.ComponentModel.DataAnnotations;

namespace TasksWebApp.Models
{
    public class Assignment : ScheduleAbstract
    {
        [Key] public int AssignmentID { get; set; }

        public Assignment(string name, string description, DateTime date) 
            : base(name, description, date)
        {
        }

        public Assignment()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksWebApp.Models
{
    public class Exam : ScheduleAbstract
    {
        [Key] public int ExamID { get; set; }
        [Required] public string CourseName { get; set; }
        public string CourseECTS { get; set; } = null;
        public string ProfessorName { get; set; } = null;
        public DateTime SecondTerm { get; set; }

        public Exam(string name, string description, DateTime date) 
            : base(name, description, date)
        {
        }
    }
}

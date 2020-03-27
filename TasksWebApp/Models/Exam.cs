using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TasksWebApp.Models
{
    public class Exam : ScheduleAbstract
    {
        [Key] 
        public int ExamID { get; set; }

        public int? CourseECTS { get; set; }
        public string ProfessorName { get; set; } = null;
        public DateTime? SecondTerm { get; set; }

        public Exam(string name, string description, DateTime date, int courseECTS, string professorName, DateTime secondTerm) 
            : base(name, description, date)
        {
            CourseECTS = courseECTS;
            ProfessorName = professorName;
            SecondTerm = secondTerm;
        }

        public Exam()
        {
            
        }
    }
}
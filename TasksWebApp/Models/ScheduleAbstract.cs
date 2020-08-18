using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TasksWebApp.Models
{
    /// <summary>
    /// Class used as blueprint for new classes of tasks.
    /// </summary>
    public abstract class ScheduleAbstract
    {
        public string Name { get; set; } 

        [MaxLength(60)]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [AllowNull]
        public DateTime Date { get; set; }

        protected ScheduleAbstract(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }

        public ScheduleAbstract()
        {
            
        }

        protected DateTime SetDateTime(int year, int month, int day, int hour, int minute, int second = 0)
        {
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
            return dateTime;
        }

    }
}

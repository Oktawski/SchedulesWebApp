using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TasksWebApp.Models
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        {
        }
    }
}

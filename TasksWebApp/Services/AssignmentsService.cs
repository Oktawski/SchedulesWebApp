using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Services
{
    public class AssignmentsService : IScheduleService<Assignment>
    {
        private readonly ScheduleContext _repository;

        public AssignmentsService(ScheduleContext repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns all assignments.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Assignment>> GetAll()
        {
            return await _repository.Assignments.ToListAsync();
        }

        /// <summary>
        /// Adds assignment to database.
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns></returns>
        public async Task Add(Assignment assignment)
        {
            _repository.Assignments.Add(assignment);
            await _repository.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes assignment from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteById(int? id)
        {
            if (id != null)
            {
                Assignment assignment = await _repository.Assignments
                    .FirstOrDefaultAsync(e => e.AssignmentID.Equals(id));
                if (assignment != null)
                {
                    _repository.Remove(assignment);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Edits assignment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assignment"></param>
        /// <returns></returns>
        public async Task EditById(int id, Assignment assignment)
        {
            Assignment assignmentToUpdate = await FindById(id);

            //I suppose it could be done better.
            if (assignmentToUpdate != null)
            {
                assignmentToUpdate.Name = assignment.Name;
                assignmentToUpdate.Description = assignment.Description;
                assignmentToUpdate.Date = assignment.Date;

                _repository.Update(assignmentToUpdate);
                await _repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Finds assignment by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Assignment> FindById(int? id)
        {
            if (id == null) return null;

            return await _repository.Assignments.FindAsync(id);
        }


    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksWebApp.Models;

namespace TasksWebApp.Services
{
    public class ExamsService : IScheduleService<Exam>
    {
        private readonly ScheduleContext _repository;

        public ExamsService(ScheduleContext repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns all exams.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Exam>> GetAll()
        {
            return await _repository.Exams.ToListAsync();
        }

        /// <summary>
        /// Adds exam to database.
        /// </summary>
        /// <param name="exam"></param>
        /// <returns></returns>
        public async Task Add(Exam exam)
        {
            _repository.Exams.Add(exam);
            await _repository.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes exam from database by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteById(int? id)
        {
            if (id != null)
            {
                Exam exam = await _repository.Exams.FirstOrDefaultAsync(e => e.ExamID.Equals(id));
                if (exam != null)
                {
                    _repository.Exams.Remove(exam);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Edits exam.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exam"></param>
        /// <returns></returns>
        public async Task EditById(int id, Exam exam)
        {
            Exam examToEdit = await FindById(id);

            if(examToEdit != null)
            {
                examToEdit = exam;
                _repository.Exams.Update(examToEdit);
                await _repository.SaveChangesAsync();
            }

        }

        public async Task<Exam> FindById(int? id)
        {
            if (id == null) return null;

            return await _repository.Exams.FirstOrDefaultAsync(e => e.ExamID.Equals(id));
        }
    }
}
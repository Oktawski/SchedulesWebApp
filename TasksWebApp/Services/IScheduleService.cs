using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksWebApp.Models;

namespace TasksWebApp.Services
{
    public interface IScheduleService<T> where T : ScheduleAbstract
    {
        Task<IEnumerable<T>> GetAll();

        Task Add(T t);

        Task DeleteById(int? id);

        Task EditById(int id, T t);

        Task<T> FindById(int? id);


    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksWebApp.Models;

namespace TasksWebApp.Interfaces
{
    public interface IScheduleController<T> where T : ScheduleAbstract
    {
        Task<IActionResult> GetAll();
        
        IActionResult Add();

        Task<IActionResult> Add(T t);

        IActionResult Edit(int? id);

        Task<IActionResult> Edit(int id, T t);

        Task<IActionResult> Delete(int? id);

    } 
}
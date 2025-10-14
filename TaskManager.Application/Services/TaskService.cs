using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Abstraction;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)=> _taskRepository = taskRepository;

        public async Task<IEnumerable<Tasks>> GetAllAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task CreateAsync(Tasks task)
        {
            await _taskRepository.CreateAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, bool isComplete)
        {
            await _taskRepository.UpdateAsync(id, isComplete);
        }
    }
}

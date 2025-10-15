using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
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

        public async Task<bool> DeleteAsync(int id)
        {
            int affectedRows = await _taskRepository.DeleteAsync(id);
            return affectedRows > 0;
        }

        public async Task<bool> UpdateAsync(int id, bool isComplete)
        {
            int affectedRows = await _taskRepository.UpdateAsync(id, isComplete);
            return affectedRows > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Abstraction
{
    public interface ITaskService
    {
        public Task<IEnumerable<Tasks>> GetAllAsync();
        public Task CreateAsync(Tasks task);
        public Task UpdateAsync(int id, bool isComplete);
        public Task DeleteAsync(int id);
    }
}

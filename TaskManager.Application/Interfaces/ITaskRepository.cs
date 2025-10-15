using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskRepository
    {
        public Task CreateAsync(Tasks task);
        public Task<int> UpdateAsync(int id, bool isComplete);
        public Task<int> DeleteAsync(int id);
        public Task<IEnumerable<Tasks>> GetAllAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Presentation.Interfaces
{
    public interface ITaskUi
    {
        public Task GetAllAsync();
        public Task CreateAsync();
        public Task DeleteAsync();
        public Task UpdateAsync();
    }
}

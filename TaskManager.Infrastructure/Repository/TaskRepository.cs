using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Abstraction;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repository
{
    public class TaskRepository:ITaskRepository
    {
        private readonly IFactoryDbConnection _connection;

        public TaskRepository(IFactoryDbConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(Tasks task)
        {
            using var connection = _connection.CreateConnection();
            const string sql = @"
                INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt)
                VALUES (@Title, @Description, @IsCompleted, @CreatedAt)";
            await connection.ExecuteAsync(sql, task);
        }

        public async Task UpdateAsync(int id, bool isComplete)
        {
            
            using var connection = _connection.CreateConnection();
            const string sql = "UPDATE Tasks SET IsCompleted = @IsCompleted WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id, IsCompleted = isComplete });
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _connection.CreateConnection();
            const string sql = "DELETE FROM Tasks WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Tasks>> GetAllAsync()
        {
            using var connection = _connection.CreateConnection();
            const string sql = "SELECT * FROM Tasks";
            return await connection.QueryAsync<Tasks>(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Presentation.Interfaces;

namespace TaskManager.Presentation.UI
{
    public class TaskUI : ITaskUi
    {
        private readonly ITaskService _taskService;

        public TaskUI(ITaskService taskService) => _taskService = taskService;

        public async Task GetAllAsync()
        {
            var tasks = await _taskService.GetAllAsync();
            foreach (var task in tasks)
            {
                Console.WriteLine($"========================\n" +
                    $"{task.Id} - {task.Title}\n" +
                    $"{task.Description}\n" +
                    $"{(task.IsCompleted ? "Выполнена" : "Не выполнена")}\n" +
                    $"Создана: {task.CreateAt}\n" +
                    $"========================");
            }
        }

        public async Task CreateAsync()
        {

            string title;
            while (true) {
                Console.WriteLine("Введите название задачи:");
                title = Console.ReadLine() ?? "";
                if(!string.IsNullOrWhiteSpace(title) )
                    break;
                Console.WriteLine("Название не может быть пустым");
            }

            string description;
            while (true)
            {
                Console.WriteLine("Введите описание задачи");
                description = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(description) )
                    break;
                Console.WriteLine("Описание не может быть пустым");
            }

            await _taskService.CreateAsync(new Tasks(title, description));
            Console.WriteLine("Задача успешно добавлена");
        }
        
        public async Task UpdateAsync()
        {
            int id;
            while (true)
            {
                Console.WriteLine("Введите Id задачи");
                if(int.TryParse(Console.ReadLine(), out id) ) 
                    break ;
                Console.WriteLine("Id введён не корректно");
            }

            bool isCompleted;
            while (true)
            {
                Console.WriteLine("Введите значение завершена ли задача?\n" +
                    "Да\n" +
                    "Нет");
                    string answer = Console.ReadLine()??"";
                    if (answer == "Да")
                    {
                        isCompleted = true;
                        break;
                    }
                    else if (answer == "Нет")
                    {
                        isCompleted = false;
                        break;
                    }
                    Console.WriteLine("Введено некорректное значение");
                
                
            }

            bool updated = await _taskService.UpdateAsync(id, isCompleted);

            if (updated)
                Console.WriteLine("Обновление завершено успешно");
            else Console.WriteLine("Не удалось обновить задачу");
        }

        public async Task DeleteAsync()
        {
            int id;
            while (true)
            {
                Console.WriteLine("Введите Id задачи");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                Console.WriteLine("Id введён не корректно");
            }
           bool deleted = await _taskService.DeleteAsync(id);
            if (deleted)
                Console.WriteLine("Удаление произведено успешно");
            else Console.WriteLine("Не удалось удалить задачу");
            
        }
    }
}

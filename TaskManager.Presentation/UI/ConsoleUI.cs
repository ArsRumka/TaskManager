using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Presentation.Interfaces;

namespace TaskManager.Presentation.UI
{
    public class ConsoleUI:IConsoleUI
    {
        private readonly ITaskUi _taskUi;
        public ConsoleUI(ITaskUi taskUi)=> _taskUi = taskUi;
        
        public async Task RunAsync()
        {
            while (true)
            {
                try
                {
                    Console.Write("Меню управления задачами\n" +
                        "1. Добавить задачу\n" +
                        "2. Посмотреть задачи\n" +
                        "3. Обновить статус задачи\n" +
                        "4. Удалить задачу\n" +
                        "0. Выход\n" +
                        "Ваш выбор: ");
                    int choice;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out choice))
                            break;
                        Console.WriteLine("Неверный ввод");
                    }

                    switch (choice)
                    {
                        case 1: await _taskUi.CreateAsync(); break;
                        case 2: await _taskUi.GetAllAsync(); break;
                        case 3: await _taskUi.UpdateAsync(); break;
                        case 4: await _taskUi.DeleteAsync(); break;
                        case 0: return;
                        default: Console.WriteLine("Неверный ввод"); break;
                    }
                    Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
                    Console.ReadKey();
                    Console.WriteLine("========================================");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}

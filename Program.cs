using System;
using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp
{
    class Program
    {
        // Esta es la lista para almacenar las tareas
        private static List<TaskItem> taskList = new List<TaskItem>();

        static void Main(string[] args)
        {
            ShowMenu();
        }

        // Este es el metodo para mostrar el menu principal
        private static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("|||||||||||||||| Gestión de Lista de Tareas ||||||||||||||||");
                Console.WriteLine("1. Agregar una nueva tarea.");
                Console.WriteLine("2. Listar todas las tareas.");
                Console.WriteLine("3. Marcar una tarea como completada.");
                Console.WriteLine("4. Eliminar una tarea.");
                Console.WriteLine("5. Salir.");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ListTasks();
                        break;
                    case "3":
                        CompleteTask();
                        break;
                    case "4":
                        RemoveTask();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }

        //Este es el metodo para agregar una nueva tarea
        private static void AddTask()
        {
            Console.Write("Ingrese la descripción de la tarea: ");
            string description = Console.ReadLine();

            Console.Write("Ingrese la fecha límite (dd/mm/aaaa) o Enter para omitir: ");
            string dateInput = Console.ReadLine();

            DateTime? dueDate = null;
            if (DateTime.TryParse(dateInput, out DateTime parsedDate))
            {
                dueDate = parsedDate;
            }

            TaskItem newTask = new TaskItem(description, dueDate);
            taskList.Add(newTask);

            Console.WriteLine("Tarea agregada correctamente.");
            Console.ReadLine();
        }

        // Este es el metodo para listar todas las tareas
        private static void ListTasks()
        {
            Console.WriteLine("==== Lista de Tareas ====");
            if (taskList.Count == 0)
            {
                Console.WriteLine("Lista vacia.");
            }
            else
            {
                for (int i = 0; i < taskList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {taskList[i]}");
                }
            }
            Console.ReadLine();
        }

        // Este es el metodo para marcar una tarea como completada
        private static void CompleteTask()
        {
            ListTasks();

            Console.Write("Seleccione el número de la tarea para marcar como completada: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {
                taskList[taskNumber - 1].MarkAsCompleted();
                Console.WriteLine("Tarea completada.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            Console.ReadLine();
        }

        // Este es el metodo para eliminar una tarea
        private static void RemoveTask()
        {
            ListTasks();

            Console.Write("Seleccione el número de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {
                taskList.RemoveAt(taskNumber - 1);
                Console.WriteLine("Eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            Console.ReadLine();
        }
    }
}

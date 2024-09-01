using System;

namespace ToDoListApp.Models
{
    public class TaskItem
    {
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public TaskItem(string description, DateTime? dueDate = null)
        {
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "Completada" : "Pendiente";
            string dueDateString = DueDate.HasValue ? $" - Fecha límite: {DueDate.Value.ToShortDateString()}" : "";
            return $"{Description} [{status}]{dueDateString}";
        }
    }
}

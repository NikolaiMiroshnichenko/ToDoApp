using System;

namespace ToDoApp.Models
{
    public class ToDoItem : Entity
    {        
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public ToDoStatus Status { get; set; }
    }

    public enum ToDoStatus
    {
        Active,
        Completed
    }
}

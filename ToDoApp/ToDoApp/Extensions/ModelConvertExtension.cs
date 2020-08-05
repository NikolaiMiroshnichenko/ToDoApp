using System.Collections.Generic;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.Extensions
{
    public static class ModelConvertExtension
    {
        public static ToDoItemViewModel ToViewModel (this ToDoItem toDoItem)
        {
            return new ToDoItemViewModel
            {
                Id = toDoItem.Id,
                Status = toDoItem.Status,
                Text = toDoItem.Text,
                Time = toDoItem.Time
            };
        }

        public static IEnumerable<ToDoItemViewModel> ToViewModels (this IEnumerable<ToDoItem>  toDoItems)
        {
            foreach(var item in toDoItems)
            {
                yield return item.ToViewModel();              
            }
        }
    }
}

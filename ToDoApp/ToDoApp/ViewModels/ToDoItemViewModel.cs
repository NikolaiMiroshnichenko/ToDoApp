using System;
using System.ComponentModel;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class ToDoItemViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public ToDoStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

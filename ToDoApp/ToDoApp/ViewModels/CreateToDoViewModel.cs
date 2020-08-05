using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ToDoApp.Helpers;
using ToDoApp.Models;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class CreateToDoViewModel: INotifyPropertyChanged
    {
        public CreateToDoViewModel()
        {
            Title = Constants.NewToDoTitle;
            CreateCommand = new Command(async () => await CreateToDo());
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

        public Command CreateCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private async Task CreateToDo()
        {
            if (Text != null)
            {
                await App.Repository.CreateAsync(new ToDoItem { Text = Text, Time = Time });
                await App.Repository.SaveAsync();
                await App.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(
                    Constants.Warning,
                    Constants.TextCantBeEmpty,
                    Constants.Back);
            }
        }     
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ToDoApp.Views;
using ToDoApp.Extensions;
using Xamarin.Forms;
using System;
using System.Linq;
using ToDoApp.Models;
using ToDoApp.Helpers;
using System.ComponentModel;
using Acr.UserDialogs;

namespace ToDoApp.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Title = Constants.MainViewTitle;
            CurrentTime = DateTime.Now;
            ToDoItems = new ObservableCollection<ToDoItemViewModel>();
            ToDoItems.CollectionChanged += ToDoItems_CollectionChanged;
            CreateToDoCommand = new Command(NavigateToCreateView);
            ChangeStatusCommand = new Command<ToDoItemViewModel>(async (vm) => await ChangeStatus(vm));
            DeleteToDoItemCommand = new Command<ToDoItemViewModel>(async(vm)=>await DeleteToDo(vm));
            ToDoItemsRefreshCommands = new Command(async()=>await InitializeToDoItems());
        }

        public DateTime CurrentTime { get; private set; }
        public string Title { get; set; }
        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; set; } 
        public bool IsRefreshing { get; set; }
        public bool IsToDoItemsListEmpty { get; set; }
        public Command ToDoItemsRefreshCommands { get; }
        public Command CreateToDoCommand { get; }
        public Command ChangeStatusCommand { get; }
        public Command DeleteToDoItemCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async Task InitializeToDoItems()
        {
            IsRefreshing = true;
            List<ToDoItemViewModel> items = (await App.Repository.GetAllAsync()).ToViewModels().ToList();
            ToDoItems.Clear();
            ToDoItems = ToDoItems.AddRange(items);
            IsRefreshing = false;
        }

        private void ToDoItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            IsToDoItemsListEmpty = ToDoItems.Count == 0;
        }

        private void NavigateToCreateView()
        {
            App.Navigation.PushAsync(new CreateToDoView());
        }

        private async Task ChangeStatus(ToDoItemViewModel vm)
        {
            vm.Status = ToDoStatus.Completed;
            var item = await App.Repository.Get(vm.Id);
            item.Status = ToDoStatus.Completed;
            App.Repository.Update(item);
            await App.Repository.SaveAsync();
        }

        private async Task DeleteToDo(ToDoItemViewModel viewModel)
        {
            var result = await UserDialogs.Instance.ConfirmAsync(
                Constants.DeleteToDoQuestion,
                Constants.Warning,
                Constants.Ok,
                Constants.Cancel);

            if (result)
            {
                ToDoItems.Remove(viewModel);
                await App.Repository.DeleteAsync(viewModel.Id);
                await App.Repository.SaveAsync();
            }            
        }
    }
}

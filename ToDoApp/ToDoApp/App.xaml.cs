using ToDoApp.Database;
using ToDoApp.DI;
using ToDoApp.Helpers;
using ToDoApp.Interfaces;
using ToDoApp.Models;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class App : Application
    {
        public App()
        {            
            InitializeComponent();
            var pathService = Bootstrapper.Get<IPath>();
            Repository = new Repository<ToDoItem>(new ApplicationContext(pathService.GetDatabasePath(Constants.DbFileName)));            
            MainPage = new CustomNavigationPage(new MainPage());
            Navigation = MainPage.Navigation;
        }

        public static INavigation Navigation { get; private set; }
        public static Repository<ToDoItem> Repository { get; set; }

        protected override void OnStart()
        {           
        }

        protected override void OnSleep()
        {                 
        }

        protected override void OnResume()
        {           
        }
    }
}

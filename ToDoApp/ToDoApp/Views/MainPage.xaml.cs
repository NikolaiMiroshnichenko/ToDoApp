using Xamarin.Forms;
using ToDoApp.Helpers;

namespace ToDoApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetNavigationPageStyle();
            ViewModel.ToDoItemsRefreshCommands.Execute(null);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ChangeStatusCommand.Execute(e.Item);
        }

        private void SetNavigationPageStyle()
        {
            if (App.Current.MainPage is CustomNavigationPage navigationPage)
            {
                navigationPage.BarBackgroundColor =
                    (Color)Application.Current.Resources[Constants.NavigationBarTransparent];
            }
        }
    }
}

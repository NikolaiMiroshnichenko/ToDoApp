using ToDoApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateToDoView : ContentPage
    {
        public CreateToDoView()
        {
            InitializeComponent();        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetNavigationPageStyle();
        }

        private void SetNavigationPageStyle()
        {
            if (App.Current.MainPage is CustomNavigationPage navigationPage)
            {
                navigationPage.BarBackgroundColor = 
                    (Color)Application.Current.Resources[Constants.NavigationBarBackgroundDark];
            }
        }
    }
}
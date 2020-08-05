using Foundation;
using ToDoApp.DI;
using ToDoApp.Interfaces;
using ToDoApp.iOS.Services;
using UIKit;

namespace ToDoApp.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SQLitePCL.Batteries_V2.Init();
            global::Xamarin.Forms.Forms.Init();
            Bootstrapper.Register<IPath, IosDbPath>();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}

# ToDoApp
Application allow user to manage his tasks. User can create new task, delete existing task, change status of task, watch all tasks.
## Architecture
Apllication consists of 4 projects: 

**ToDoApp.Interfaces**
This project contains interfaces

**ToDoApp** 
This project is standard Xamarin.Forms Shared project, contain view models, XAML views.

**ToDoApp.Android**
Xamarin.Forms Android client

**ToDoApp.iOS**
Xamarin.Forms iOS client

## Used libraries
- SimpleInjector for DI
- PropertyChanged.Fody for MVVM simplicity
- ACR.UserDialogs for using dialogs from view model

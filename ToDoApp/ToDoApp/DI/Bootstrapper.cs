using SimpleInjector;
using ToDoApp.Interfaces;

namespace ToDoApp.DI
{
    public static class Bootstrapper
    {
        public static Container Container = new Container();

        public static TService Get<TService>() 
            where TService: class
        {
            return Container.GetInstance<TService>();
        }

        public static  void Register<TService, TImplementation>()
             where TService : class
             where TImplementation : class, TService
        {
            Container.Register<TService, TImplementation>();
        }           
    }
}

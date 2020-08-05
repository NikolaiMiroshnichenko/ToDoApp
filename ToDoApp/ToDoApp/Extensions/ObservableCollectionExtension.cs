using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToDoApp.Extensions
{
    public static class ObservableCollectionExtension 
    {
        public static ObservableCollection<T> AddRange<T> (this ObservableCollection <T> observableCollection, List<T> list)
        {
            foreach(var item in list)
            {
                observableCollection.Add(item);
            }
            return observableCollection;
        }
    }
}

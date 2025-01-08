using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShoppingListApp.Models
{
    public class ShoppingListManager : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; } = new();

        public ShoppingListManager()
        {
            Items.CollectionChanged += (s, e) => NotifyPropertyChanged(nameof(PendingItems));
        }

        public IEnumerable<Item> PendingItems => Items.Where(item => !item.Purchased);

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class DataStore
    {
        public static ShoppingListManager Instance { get; } = new ShoppingListManager();
    }
}




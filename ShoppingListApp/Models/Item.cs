using System.ComponentModel;

namespace ShoppingListApp.Models
{
    public class Item : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string UnitType { get; set; }
        public string Category { get; set; }

        private bool _purchased;
        public bool Purchased
        {
            get => _purchased;
            set
            {
                if (_purchased != value)
                {
                    _purchased = value;
                    NotifyPropertyChanged(nameof(Purchased));
                }
            }
        }

        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    NotifyPropertyChanged(nameof(Amount));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

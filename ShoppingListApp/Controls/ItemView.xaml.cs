using ShoppingListApp.Models;

namespace ShoppingListApp.Controls
{
    public partial class ItemView : ContentView
    {
        public ItemView(Item item, Action<Item> increment, Action<Item> decrement, Action<Item> togglePurchased, Action<Item> remove)
        {
            InitializeComponent();
            BindingContext = item;

            IncrementButton.Clicked += (s, e) => increment(item);
            DecrementButton.Clicked += (s, e) => decrement(item);
            PurchasedButton.Clicked += (s, e) => togglePurchased(item);
            RemoveButton.Clicked += (s, e) => remove(item);
        }
    }
}

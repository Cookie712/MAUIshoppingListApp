using System.Text.Json;
using ShoppingListApp.Controls;
using ShoppingListApp.Models;

namespace ShoppingListApp.Views
{
    public partial class ShoppingListPage : ContentPage
    {
        private readonly string _dataFilePath = Path.Combine(FileSystem.AppDataDirectory, "shopping_list.json");

        public ShoppingListPage()
        {
            InitializeComponent();
            BindingContext = DataStore.Instance;
            LoadData();
        }

        private void AddNewItem(object sender, EventArgs e)
        {
            if (BindingContext is ShoppingListManager manager && CreateNewItem(out var newItem))
            {
                manager.Items.Add(newItem);
                ClearInputFields();
                SaveData();
                UpdateListDisplay();
            }
        }

        private bool CreateNewItem(out Item newItem)
        {
            newItem = null;

            if (string.IsNullOrWhiteSpace(ItemNameEntry.Text) ||
                string.IsNullOrWhiteSpace(ItemUnitEntry.Text) ||
                !int.TryParse(ItemAmountEntry.Text, out var amount) ||
                amount <= 0)
            {
                DisplayAlert("Invalid Input", "Please fill in all fields correctly.", "OK");
                return false;
            }

            newItem = new Item
            {
                Title = ItemNameEntry.Text,
                UnitType = ItemUnitEntry.Text,
                Amount = amount
            };

            return true;
        }

        private void SaveData()
        {
            try
            {
                if (BindingContext is ShoppingListManager manager)
                {
                    var jsonData = JsonSerializer.Serialize(manager.Items.ToList());
                    File.WriteAllText(_dataFilePath, jsonData);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Unable to save data: {ex.Message}", "OK");
            }
        }

        private void LoadData()
        {
            if (BindingContext is ShoppingListManager manager)
            {
                manager.Items.Clear();

                if (File.Exists(_dataFilePath))
                {
                    try
                    {
                        var jsonData = File.ReadAllText(_dataFilePath);
                        var loadedItems = JsonSerializer.Deserialize<List<Item>>(jsonData) ?? new List<Item>();

                        foreach (var item in loadedItems)
                            manager.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Error", $"Unable to load data: {ex.Message}", "OK");
                    }
                }

                UpdateListDisplay();
            }
        }

        private void UpdateListDisplay()
        {
            ItemListView.Children.Clear();

            if (BindingContext is ShoppingListManager manager)
            {
                var sortedItems = manager.Items.OrderBy(item => item.Purchased).ToList();

                foreach (var item in sortedItems)
                {
                    var itemView = new ItemView(item, IncrementAmount, DecrementAmount, TogglePurchased, RemoveItem);
                    ItemListView.Children.Add(itemView);
                }
            }
        }


        private void IncrementAmount(Item item)
        {
            item.Amount++;
            SaveData();
        }

        private void DecrementAmount(Item item)
        {
            if (item.Amount > 0)
                item.Amount--;
            SaveData();
        }

        private void RemoveItem(Item item)
        {
            if (BindingContext is ShoppingListManager manager)
            {

                if (manager.Items.Contains(item))
                {
                    manager.Items.Remove(item);
                    SaveData();  
                    UpdateListDisplay();  
                }
                else
                {
                    DisplayAlert("Error", "Unable to remove item. Item not found.", "OK");
                }
            }
        }

        private void TogglePurchased(Item item)
        {
            item.Purchased = !item.Purchased;
            SaveData();
            UpdateListDisplay();
        }

        private void ClearInputFields()
        {
            ItemNameEntry.Text = string.Empty;
            ItemUnitEntry.Text = string.Empty;
            ItemAmountEntry.Text = string.Empty;
        }
    }
}

using ShoppingListApp.Models;
using ShoppingListApp.Views;
using System.Collections.ObjectModel;

namespace ShoppingListApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingList> ShoppingLists { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ShoppingLists = new ObservableCollection<ShoppingList>();
            BindingContext = this;

            // Dodaj predefiniowane listy zakupowe
            AddPredefinedShoppingLists();
        }

        private void AddPredefinedShoppingLists()
        {
            var predefinedList = new ShoppingList
            {
                Name = "Predefiniowana lista",
                Categories = new ObservableCollection<Category>
                {
                    new Category { Name = "Nabiał", Products = new ObservableCollection<Product>(), IsExpanded = false },
                    new Category { Name = "Warzywa", Products = new ObservableCollection<Product>(), IsExpanded = false },
                    new Category { Name = "Elektronika", Products = new ObservableCollection<Product>(), IsExpanded = false },
                    new Category { Name = "AGD", Products = new ObservableCollection<Product>(), IsExpanded = false }
                }
            };
            ShoppingLists.Add(predefinedList);
        }

        private async void AddShoppingListButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddShoppingListPage(ShoppingLists));
        }

        private async void OpenShoppingListButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var selectedList = (ShoppingList)button.CommandParameter;
            await Navigation.PushAsync(new ShoppingListView(selectedList));
        }
    }
}

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

            // Dodaj domyślne produkty
            AddDefaultProducts(predefinedList);

            ShoppingLists.Add(predefinedList);
        }

        private void AddDefaultProducts(ShoppingList shoppingList)
        {
            var defaultProducts = new List<Product>
            {
                new Product { Name = "Mleko", Unit = "l", Quantity = 1 },
                new Product { Name = "Chleb", Unit = "szt.", Quantity = 1 },
                new Product { Name = "Jabłka", Unit = "kg", Quantity = 1 },
                new Product { Name = "Masło", Unit = "g", Quantity = 200 },
                new Product { Name = "Jogurt", Unit = "szt.", Quantity = 2 },
                new Product { Name = "Pomidory", Unit = "kg", Quantity = 1 },
                new Product { Name = "Ogórki", Unit = "szt.", Quantity = 5 },
                new Product { Name = "Ser", Unit = "g", Quantity = 300 },
                new Product { Name = "Szynka", Unit = "g", Quantity = 200 },
                new Product { Name = "Jajka", Unit = "szt.", Quantity = 10 },
                new Product { Name = "Cukier", Unit = "kg", Quantity = 1 },
                new Product { Name = "Mąka", Unit = "kg", Quantity = 1 },
                new Product { Name = "Ryż", Unit = "kg", Quantity = 1 },
                new Product { Name = "Makaron", Unit = "g", Quantity = 500 },
                new Product { Name = "Oliwa", Unit = "ml", Quantity = 500 },
                new Product { Name = "Masło orzechowe", Unit = "g", Quantity = 300 },
                new Product { Name = "Kawa", Unit = "g", Quantity = 250 },
                new Product { Name = "Herbata", Unit = "szt.", Quantity = 20 },
                new Product { Name = "Sok pomarańczowy", Unit = "l", Quantity = 1 },
                new Product { Name = "Woda", Unit = "l", Quantity = 2 }
            };

            foreach (var product in defaultProducts)
            {
                shoppingList.Categories.First().Products.Add(product);
            }
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

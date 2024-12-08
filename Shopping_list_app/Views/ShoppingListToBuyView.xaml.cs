using System.Collections.ObjectModel;
using System.Linq;
using ShoppingListApp.Models;

namespace ShoppingListApp.Views
{
    public partial class ShoppingListToBuyView : ContentPage
    {
        public ObservableCollection<Product> ProductsToBuy { get; set; }

        public ShoppingListToBuyView(ShoppingList shoppingList)
        {
            InitializeComponent();
            ProductsToBuy = new ObservableCollection<Product>(shoppingList.Categories
                .SelectMany(category => category.Products)
                .Where(product => !product.IsPurchased)
                .OrderBy(product => product.Category.Name)
                .ThenBy(product => product.Name));
            BindingContext = this;
        }
    }
}



using ShoppingListApp.Models;
using System;

namespace ShoppingListApp.Views
{
    public partial class ShoppingListView : ContentPage
    {
        public ShoppingList ShoppingList { get; set; }

        public ShoppingListView(ShoppingList shoppingList)
        {
            InitializeComponent();
            ShoppingList = shoppingList;
            BindingContext = ShoppingList;
        }

        private async void AddProductButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage(ShoppingList));
        }
    }
}

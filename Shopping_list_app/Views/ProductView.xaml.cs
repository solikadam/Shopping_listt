using ShoppingListApp.Models;
using System;

namespace ShoppingListApp.Views
{
    public partial class ProductView : ContentView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void IncreaseQuantity(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            product.Quantity++;
        }

        private void DecreaseQuantity(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            if (product.Quantity > 0)
                product.Quantity--;
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            var category = (Category)((ContentView)Parent).BindingContext;
            category.Products.Remove(product);
        }

        private void OnPurchasedChanged(object sender, CheckedChangedEventArgs e)
        {
            var product = (Product)BindingContext;
            product.IsPurchased = e.Value;

            // Przenieœ produkt na koniec listy kategorii
            var category = (Category)((ContentView)Parent).BindingContext;
            category.Products.Move(category.Products.IndexOf(product), category.Products.Count - 1);
        }
    }
}

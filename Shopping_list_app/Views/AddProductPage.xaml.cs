using ShoppingListApp.Models;
using System;
using System.Linq;

namespace ShoppingListApp.Views
{
    public partial class AddProductPage : ContentPage
    {
        public ShoppingList ShoppingList { get; set; }

        public AddProductPage(ShoppingList shoppingList)
        {
            InitializeComponent();
            ShoppingList = shoppingList;

            // Wype³nij Picker kategoriami
            foreach (var category in ShoppingList.Categories)
            {
                CategoryPicker.Items.Add(category.Name);
            }

            // Wype³nij Picker jednostkami
            ProductUnitPicker.Items.Add("szt.");
            ProductUnitPicker.Items.Add("kg");
            ProductUnitPicker.Items.Add("l");
            ProductUnitPicker.Items.Add("g");
            ProductUnitPicker.Items.Add("ml");
        }

        private async void AddProductButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ProductNameEntry.Text) &&
                !string.IsNullOrWhiteSpace(ProductQuantityEntry.Text) &&
                ProductUnitPicker.SelectedIndex >= 0 &&
                CategoryPicker.SelectedIndex >= 0)
            {
                var selectedCategory = ShoppingList.Categories.ElementAt(CategoryPicker.SelectedIndex);
                var newProduct = new Product
                {
                    Name = ProductNameEntry.Text,
                    Quantity = int.Parse(ProductQuantityEntry.Text),
                    Unit = ProductUnitPicker.SelectedItem.ToString()
                };
                selectedCategory.Products.Add(newProduct);

                // Odœwie¿ interfejs u¿ytkownika
                OnPropertyChanged(nameof(ShoppingList));

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("B³¹d", "Wype³nij wszystkie pola.", "OK");
            }
        }
    }
}

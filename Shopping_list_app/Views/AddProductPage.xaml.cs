using ShoppingListApp.Models;
using ShoppingListApp.Views;
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

            // Wype�nij Picker kategoriami
            foreach (var category in ShoppingList.Categories)
            {
                CategoryPicker.Items.Add(category.Name);
            }

            // Wype�nij Picker jednostkami
            ProductUnitPicker.Items.Add("szt.");
            ProductUnitPicker.Items.Add("kg");
            ProductUnitPicker.Items.Add("l");
            ProductUnitPicker.Items.Add("g");
            ProductUnitPicker.Items.Add("ml");

            // Wype�nij Picker dost�pnymi produktami
            foreach (var product in Product.AvailableProducts)
            {
                ProductPicker.Items.Add(product.Name);
            }
        }

        private async void AddProductButton_Clicked(object sender, EventArgs e)
        {
            if (ProductPicker.SelectedIndex >= 0 &&
                !string.IsNullOrWhiteSpace(ProductQuantityEntry.Text) &&
                ProductUnitPicker.SelectedIndex >= 0 &&
                CategoryPicker.SelectedIndex >= 0)
            {
                var selectedCategory = ShoppingList.Categories.ElementAt(CategoryPicker.SelectedIndex);
                var selectedProduct = Product.AvailableProducts.ElementAt(ProductPicker.SelectedIndex);
                var newProduct = new Product(selectedCategory)
                {
                    Name = selectedProduct.Name,
                    Quantity = int.Parse(ProductQuantityEntry.Text),
                    Unit = ProductUnitPicker.SelectedItem.ToString()
                };
                selectedCategory.Products.Add(newProduct);

                // Od�wie� interfejs u�ytkownika
                OnPropertyChanged(nameof(ShoppingList));

                await Navigation.PopAsync();
            }
            else if (!string.IsNullOrWhiteSpace(NewProductNameEntry.Text) &&
                     !string.IsNullOrWhiteSpace(ProductQuantityEntry.Text) &&
                     ProductUnitPicker.SelectedIndex >= 0 &&
                     CategoryPicker.SelectedIndex >= 0)
            {
                var selectedCategory = ShoppingList.Categories.ElementAt(CategoryPicker.SelectedIndex);
                var newProduct = new Product(selectedCategory)
                {
                    Name = NewProductNameEntry.Text,
                    Quantity = int.Parse(ProductQuantityEntry.Text),
                    Unit = ProductUnitPicker.SelectedItem.ToString()
                };
                selectedCategory.Products.Add(newProduct);

                // Dodaj nowy produkt do globalnej listy dost�pnych produkt�w
                Product.AvailableProducts.Add(newProduct);

                // Od�wie� interfejs u�ytkownika
                OnPropertyChanged(nameof(ShoppingList));

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("B��d", "Wype�nij wszystkie pola.", "OK");
            }
        }
    }
}

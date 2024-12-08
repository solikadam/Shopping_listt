using ShoppingListApp.Models;
using ShoppingListApp.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingListApp.Views
{
    public partial class ShoppingListView : ContentPage
    {
        private readonly DataService _dataService;

        public ShoppingList ShoppingList { get; set; }

        public ShoppingListView(ShoppingList shoppingList)
        {
            InitializeComponent();
            ShoppingList = shoppingList;
            _dataService = new DataService();
            BindingContext = ShoppingList;
        }

        private async void AddProductButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage(ShoppingList));
        }

        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryPage(ShoppingList));
        }

        private async void ExportListButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // U�ycie domy�lnego katalogu aplikacji
                string filePath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.xml");

                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    _dataService.ExportShoppingList(ShoppingList, stream);
                }

                await DisplayAlert("Eksport", $"Lista zakup�w zosta�a zapisana w lokalizacji:\n{filePath}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("B��d", $"Wyst�pi� problem podczas eksportu: {ex.Message}", "OK");
            }
        }

        private async void ImportListButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.xml");

                if (!File.Exists(filePath))
                {
                    await DisplayAlert("Import", "Plik ShoppingList.xml nie istnieje w katalogu aplikacji.", "OK");
                    return;
                }

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var importedList = _dataService.ImportShoppingList(stream);
                    ShoppingList.Categories = importedList.Categories;
                }

                await DisplayAlert("Import", "Lista zakup�w zosta�a zaimportowana.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("B��d", $"Wyst�pi� problem podczas importu: {ex.Message}", "OK");
            }
        }
    }
}

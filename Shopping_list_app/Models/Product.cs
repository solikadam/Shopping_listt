using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingListApp.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string unit;
        private int quantity;
        private bool isPurchased;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Unit
        {
            get => unit;
            set
            {
                if (unit != value)
                {
                    unit = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsPurchased
        {
            get => isPurchased;
            set
            {
                if (isPurchased != value)
                {
                    isPurchased = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Globalna lista dostępnych produktów
        public static ObservableCollection<Product> AvailableProducts { get; set; } = new ObservableCollection<Product>
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
    }
}

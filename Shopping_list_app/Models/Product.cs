using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ShoppingListApp.Models
{
    [XmlInclude(typeof(Product))]
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string unit;
        private int quantity;
        private bool isPurchased;
        private Category category;

        public Product()
        {
        }

        public Product(Category category)
        {
            this.category = category;
        }

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

        [XmlIgnore]
        public Category Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
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
            new Product(null) { Name = "Mleko", Unit = "l", Quantity = 1 },
            new Product(null) { Name = "Chleb", Unit = "szt.", Quantity = 1 },
            new Product(null) { Name = "Jabłka", Unit = "kg", Quantity = 1 },
            new Product(null) { Name = "Masło", Unit = "g", Quantity = 200 },
            new Product(null) { Name = "Jogurt", Unit = "szt.", Quantity = 2 },
            new Product(null) { Name = "Pomidory", Unit = "kg", Quantity = 1 },
            new Product(null) { Name = "Ogórki", Unit = "szt.", Quantity = 5 },
            new Product(null) { Name = "Ser", Unit = "g", Quantity = 300 },
            new Product(null) { Name = "Szynka", Unit = "g", Quantity = 200 },
            new Product(null) { Name = "Jajka", Unit = "szt.", Quantity = 10 },
            new Product(null) { Name = "Cukier", Unit = "kg", Quantity = 1 },
            new Product(null) { Name = "Mąka", Unit = "kg", Quantity = 1 },
            new Product(null) { Name = "Ryż", Unit = "kg", Quantity = 1 },
            new Product(null) { Name = "Makaron", Unit = "g", Quantity = 500 },
            new Product(null) { Name = "Oliwa", Unit = "ml", Quantity = 500 },
            new Product(null) { Name = "Masło orzechowe", Unit = "g", Quantity = 300 },
            new Product(null) { Name = "Kawa", Unit = "g", Quantity = 250 },
            new Product(null) { Name = "Herbata", Unit = "szt.", Quantity = 20 },
            new Product(null) { Name = "Sok pomarańczowy", Unit = "l", Quantity = 1 },
            new Product(null) { Name = "Woda", Unit = "l", Quantity = 2 }
        };
    }
}

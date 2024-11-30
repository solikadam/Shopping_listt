using ShoppingListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingListApp.Services
{
    public class DataService
    {
        public void SaveShoppingList(ShoppingList shoppingList, string filePath)
        {
            var serializer = new XmlSerializer(typeof(ShoppingList));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, shoppingList);
            }
        }

        public ShoppingList LoadShoppingList(string filePath)
        {
            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(ShoppingList));
                using (var reader = new StreamReader(filePath))
                {
                    return (ShoppingList)serializer.Deserialize(reader);
                }
            }
            return new ShoppingList();
        }

        public void ExportShoppingList(ShoppingList shoppingList, string filePath)
        {
            var serializer = new XmlSerializer(typeof(ShoppingList));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, shoppingList);
            }
        }

        public ShoppingList ImportShoppingList(string filePath)
        {
            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(ShoppingList));
                using (var reader = new StreamReader(filePath))
                {
                    return (ShoppingList)serializer.Deserialize(reader);
                }
            }
            return new ShoppingList();
        }
    }
}

using ShoppingListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using System.IO;
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

        public void ExportShoppingList(ShoppingList shoppingList, Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(ShoppingList));
            serializer.Serialize(fileStream, shoppingList);
        }

        public ShoppingList ImportShoppingList(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(ShoppingList));
            return (ShoppingList)serializer.Deserialize(fileStream);
        }
    }
}
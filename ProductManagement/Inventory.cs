using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.ProductManagement
{
    internal class Inventory
    {
        private List<Product> products = new(); 

        public Inventory() {

        }

        public List<Product> Products {  get { return products; } }

        public void AddProduct (Product product)
        {
            products.Add (product);
        }

        public void PrintInventory()
        {
            foreach (Product product in products) {
            product.PrintProduct();
            }
        }
  

        public Product FindProductByName(string productName)
        {
            Product product = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            return product;
        }

        public int FindProductIndex(string productName)
        {
            return products.FindIndex(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            
        }

    }
}

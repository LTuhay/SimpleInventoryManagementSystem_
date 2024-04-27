using SimpleInventoryManagementSystem.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    internal class Utilities
    {
        private static Inventory inventory = new Inventory();
        internal static void ShowMainMenu()
        {
            bool exit = false;

                Console.WriteLine("* Welcome! *");
            do
            {

                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");

                Console.WriteLine("1: Add product");
                Console.WriteLine("2: View all products");
                Console.WriteLine("0: Exit");

                string? userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowCreateNewProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "0":
                        exit = true;
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again");
                        break;
                }
            } while (!exit);

        }

        private static void ViewAllProducts()
        {
            Console.WriteLine("* All Products *");
            inventory.PrintInventory();
        }

        private static void ShowCreateNewProduct()
        {
            int id;
            string name;
            double price;
            string priceStr;
            int quantity;
            string quantityStr;

            if (inventory.Products.Count ==0)
            {
                id = 0;
            }
            else
            {
                id = inventory.Products.Max(p => p.Id) + 1;
            }

            do
            {
                Console.WriteLine("Insert new product name");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            do
            {
                Console.WriteLine("Insert new product price");
                priceStr = Console.ReadLine();
            } while (!double.TryParse(priceStr, out price));

            do
            {
                Console.WriteLine("Insert quantity");
                quantityStr = Console.ReadLine();
            } while (!int.TryParse(quantityStr, out quantity));

            Product newProduct = new Product(id, name, price);
            newProduct.IncreaseQuantity(quantity);
            inventory.AddProduct(newProduct);
        }

        private static void Exit()
        {
            Console.WriteLine("Goodbye!");

        }
    }
}

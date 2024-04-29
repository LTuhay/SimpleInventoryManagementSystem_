using SimpleInventoryManagementSystem.ProductManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Console.WriteLine("3: Update a product");
                Console.WriteLine("4: Delete a product");
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
                    case "3":
                        ShowUpdateAProduct();
                        break;
                    case "4":
                        DeleteAProduct();
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

        private static void DeleteAProduct()
        {
            string productName;
            do
            {
                Console.WriteLine("Which producto would you like to delete?");
                productName = Console.ReadLine();
            } while ( string.IsNullOrEmpty(productName));

            Product productToDelete = inventory.FindProductByName(productName);
            if (productToDelete == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                inventory.RemoveProduct(productToDelete);
                Console.WriteLine("* Product deleted *");
            }

        }

        private static void ShowUpdateAProduct()
        {
            string productName;
            do
            {
                Console.WriteLine("Which product would you like to update?");
                productName = Console.ReadLine();
            } while (String.IsNullOrEmpty(productName));

            Product productToUpdate = inventory.FindProductByName(productName);
            if (productToUpdate == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                bool exit = false;
                string newName;
                string newPriceStr;
                double newPrice;
                string increaseQuantityStr;
                int increaseQuantity;
                string decreaseQuantityStr;
                int decreaseQuantity;

                int index = inventory.FindProductIndex(productName);
                do
                {
                    Console.WriteLine($"* Updating {productToUpdate.Name} *");
                    Console.WriteLine("********************");
                    Console.WriteLine("* Select an option *");
                    Console.WriteLine("********************");

                    Console.WriteLine("1: Update name");
                    Console.WriteLine("2: Update price");
                    Console.WriteLine("3: Increase quantity");
                    Console.WriteLine("4: Decrease quantity");
                    Console.WriteLine("0: Finish");
                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            do
                            {
                                Console.WriteLine("Enter new product name");
                                newName = Console.ReadLine();
                            } while (string.IsNullOrEmpty(newName));
                            productToUpdate.Name = newName;
                            break;
                        case "2":
                            do
                            {
                                Console.WriteLine("Enter new product price");
                                newPriceStr = Console.ReadLine();
                            } while (!double.TryParse(newPriceStr, out newPrice));
                            productToUpdate.Price = newPrice;
                            break;
                        case "3":
                            do
                            {
                                Console.WriteLine("Enter quantity to increase");
                                increaseQuantityStr = Console.ReadLine();
                            } while (!int.TryParse(increaseQuantityStr, out increaseQuantity));
                            productToUpdate.IncreaseQuantity(increaseQuantity);
                            break;
                        case "4":
                            do
                            {
                                Console.WriteLine("Enter quantity to decrease");
                                decreaseQuantityStr = Console.ReadLine();
                            } while (!int.TryParse(decreaseQuantityStr, out decreaseQuantity));
                            productToUpdate.DecreaseQuantity(decreaseQuantity);
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again");
                            break;
                    }

                } while (!exit);

                inventory.Products[index] = productToUpdate;
                Console.WriteLine("* Product updated *");                
            }


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
